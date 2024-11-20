using QuizzApp.Models;

namespace QuizzApp.Interfaces.Persistance;

public interface IUserRepository{
    User? GetUserByEmail(string email);
    void Add(User user);

}