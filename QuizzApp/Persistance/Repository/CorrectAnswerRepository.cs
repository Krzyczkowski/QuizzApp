using QuizzApp.Models;

public class CorrectAnswerRepository : ICorrectAnswerRepository
{
    private readonly QuizzAppDbContext _quizzAppDbContext;

    public CorrectAnswerRepository(QuizzAppDbContext quizzAppDbContext)
    {
        _quizzAppDbContext = quizzAppDbContext;
    }
    public CorrectAnswer? Add(CorrectAnswer correctAnswer)
    {
       _quizzAppDbContext.CorrectAnswer.Add(correctAnswer);
       _quizzAppDbContext.SaveChanges();
       return correctAnswer;
    }
}