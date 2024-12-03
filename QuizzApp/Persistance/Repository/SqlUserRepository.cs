using QuizzApp.Interfaces.Persistance;
using QuizzApp.Models;

namespace QuizzApp.Persistance.Repostiory;
public class SqlUserRepository : IUserRepository
{
    private readonly QuizzAppDbContext _context;

    public SqlUserRepository(QuizzAppDbContext context)
    {
        _context = context;
    }

    public User? GetUserByEmail(string email)
    {
        return _context.Users.SingleOrDefault(user => user.Email == email);
    }
    public User? GetUserById(Guid id)
    {
        return _context.Users.SingleOrDefault(user => user.Id == id);
    }
    public void Add(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }
    public Dictionary<string,int> GetUserCorrectAnswersCount(Guid userId)
    {
        var query = _context.CorrectAnswer.AsQueryable();
        query = query.Where(q=>q.User.Id == userId);
        return query.GroupBy(q=>q.Category).ToDictionary(g=>g.Key,g=>g.Count());
    }
}