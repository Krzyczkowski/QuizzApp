using QuizzApp.Common.Interfaces.Authentication;
using QuizzApp.Contracts.Authentication;
using QuizzApp.Interfaces.Services;
using QuizzApp.Interfaces.Persistance;
using QuizzApp.Services;
using QuizzApp.Models;
public class AuthenticationService : IAuthenticationService
{

    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Login(LoginRequest loginRequest)
    {
        var user = _userRepository.GetUserByEmail(loginRequest.Email);
        if(user is null){
            throw new Exception("User with given email doesnt exists.");
        }
        if(user.Password != loginRequest.Password){
            throw new Exception("Invalid password.");
        }
        
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token
        );
    }
    public AuthenticationResult Register(RegisterRequest registerRequest)
    {

        if (_userRepository.GetUserByEmail(registerRequest.Email) is not null)
        {
            throw new Exception("User with given email already exists.");
        }
        var user = new User(registerRequest.FirstName,
          registerRequest.LastName,
          registerRequest.Email,
          registerRequest.Password
          );
        _userRepository.Add(user);

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token
        );
    }
}