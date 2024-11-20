
namespace QuizzApp.Models;
public class CorrectAnswer{
   public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid QuestionId { get; set; }
    public required string Category { get; set; }
    public int PointsAwarded { get; set; }
    public required User User { get; set; }
    public required Question Question { get; set; }

}