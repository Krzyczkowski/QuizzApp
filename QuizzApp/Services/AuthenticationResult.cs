using QuizzApp.Models;
namespace QuizzApp.Services;
public record AuthenticationResult(User user, string Token);