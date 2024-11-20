using QuizzApp.Models;

namespace QuizzApp.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator{
    string GenerateToken(User user);
}