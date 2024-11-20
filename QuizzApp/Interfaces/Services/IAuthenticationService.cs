using QuizzApp.Contracts.Authentication;
using QuizzApp.Services;

namespace QuizzApp.Interfaces.Services;

public interface IAuthenticationService{
    AuthenticationResult Login(LoginRequest loginRequest);
    AuthenticationResult Register(RegisterRequest registerRequest);
}