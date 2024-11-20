using QuizzApp.Interfaces.Persistance;
using QuizzApp.Models;

namespace QuizzApp.Persistance.Repostiory;
public class SqlUserRepository : IUserRepository
{
    private readonly QuizzAppDbContext _quizzAppDbContext;

    
    public SqlUserRepository(QuizzAppDbContext quizzAppDbContext)
    {
        _quizzAppDbContext = quizzAppDbContext;
    }

    public void Add(User user)
    {
        throw new NotImplementedException();
    }

    public User? GetUserByEmail(string email)
    {
        throw new NotImplementedException();
    }
}
