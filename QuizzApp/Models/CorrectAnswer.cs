
namespace QuizzApp.Models;
public class CorrectAnswer
{
    public Guid Id { get; set; }
    public string Category { get; set; }
    public int PointsAwarded { get; set; }
    public User User { get; set; }
    public Question Question { get; set; }

    public CorrectAnswer()
    {
    }

    public CorrectAnswer(Guid id, string category, int pointsAwarded, User user, Question question)
    {
        Id = id;
        Category = category ?? throw new ArgumentNullException(nameof(category)); 
        PointsAwarded = pointsAwarded;
        User = user ?? throw new ArgumentNullException(nameof(user)); 
        Question = question ?? throw new ArgumentNullException(nameof(question)); 
    }
}
