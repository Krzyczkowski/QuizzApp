using QuizzApp.Interfaces.Persistence;
using QuizzApp.Models;

public class QuestionRepository : IQuestionRepository
{
    private readonly QuizzAppDbContext _quizzAppDbContext;

    public QuestionRepository(QuizzAppDbContext quizzAppDbContext){
        _quizzAppDbContext = quizzAppDbContext;
    }
    public Question? Add(Question question)
    {
        _quizzAppDbContext.Add(question);
        _quizzAppDbContext.SaveChanges();
        return question;
    }

    public Question? Get(string category, string difficulty, string type)
    {
        throw new NotImplementedException();
    }
}