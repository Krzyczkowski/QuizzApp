using QuizzApp.Interfaces.Persistence;
using QuizzApp.Models;

public class QuestionRepository : IQuestionRepository
{
    private readonly QuizzAppDbContext _quizzAppDbContext;

    public QuestionRepository(QuizzAppDbContext quizzAppDbContext)
    {
        _quizzAppDbContext = quizzAppDbContext;
    }
    public Question? Add(Question question)
    {
        _quizzAppDbContext.Add(question);
        _quizzAppDbContext.SaveChanges();
        return question;
    }

    public IEnumerable<Question>? Get(string category, string difficulty, string type, int take)
    {
        var query = _quizzAppDbContext.Question.AsQueryable();
        if (category != "random")
            query = query.Where(q => q.Category == category);

        if (difficulty != "random")
            query = query.Where(q => q.Difficulty == difficulty);

        if (type != "random")
            query = query.Where(q => q.Type == type);
        

        // losowość:
        query = query.OrderBy(q => Guid.NewGuid()); 

        return query.Take(take).ToList();

    }
}