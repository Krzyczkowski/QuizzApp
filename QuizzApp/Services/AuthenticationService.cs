using QuizzApp.Common.Interfaces.Authentication;
using QuizzApp.Contracts.Authentication;
using QuizzApp.Interfaces.Services;
using QuizzApp.Interfaces.Persistance;
using QuizzApp.Services;
public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;


    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository){
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Login(LoginRequest loginRequest)
    {
        throw new NotImplementedException();
    }

    public AuthenticationResult Register(RegisterRequest registerRequest)
    {
        throw new NotImplementedException();
    }
}