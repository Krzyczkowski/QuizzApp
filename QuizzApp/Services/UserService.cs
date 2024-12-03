using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizzApp.Interfaces.Persistance;
using QuizzApp.Models;

public class UserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUserRepository _userRepository;

    public UserService(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository)
    {
        _httpContextAccessor = httpContextAccessor;
        _userRepository = userRepository;
    }

    public string GetCurrentUserId()
    {
        var user = _httpContextAccessor.HttpContext?.User;
        if (user == null)
        {
            throw new InvalidOperationException("Brak zalogowanego użytkownika.");
        }

        return user.FindFirst(ClaimTypes.NameIdentifier)?.Value
               ?? throw new InvalidOperationException("Nie znaleziono ID użytkownika w tokenie.");
    }
    public User? GetCurrentUser()
    {
        var user = _httpContextAccessor.HttpContext?.User;
        if (user == null)
        {
            throw new InvalidOperationException("Brak zalogowanego użytkownika.");
        }

        var idClaim = user.FindFirst(ClaimTypes.NameIdentifier)?.Value
               ?? throw new InvalidOperationException("Nie znaleziono ID użytkownika w tokenie.");
        Guid.TryParse(idClaim, out var userId);
        return _userRepository.GetUserById(userId);
    }

    public IActionResult GetPoints()
    {
        User? user = GetCurrentUser();
        if (user is not null)
        {
           var result= _userRepository.GetUserCorrectAnswersCount(user.Id);
           return new OkObjectResult(result);
        }
         throw new InvalidOperationException("Nie znaleziono użytkownika");

    }

}
