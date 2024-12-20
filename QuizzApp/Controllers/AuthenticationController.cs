using QuizzApp.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using QuizzApp.Interfaces.Services;

namespace BuberBreakfast.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase{

    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService){
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request){
        var authResult = _authenticationService.Register(request);

        var response = new AuthenticationResponse(
            authResult.user.Id,
            authResult.user.FirstName,
            authResult.user.LastName,
            authResult.user.Email,
            authResult.Token
        );

        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request){
        var authResult = _authenticationService.Login(request);
        var response = new AuthenticationResponse(
            authResult.user.Id,
            authResult.user.FirstName,
            authResult.user.LastName,
            authResult.user.Email,
            authResult.Token
        );
        return Ok(response);
    }
}