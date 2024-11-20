using QuizzApp.Models;
namespace QuizzApp.Interfaces.Persistence;
public interface IQuestionRepository
{
    Question? GetQuestion(string category, string difficulty, string type);
}