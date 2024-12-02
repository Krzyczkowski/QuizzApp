using QuizzApp.Models;
namespace QuizzApp.Interfaces.Persistence;
public interface IQuestionRepository
{
    Question? Get(string category, string difficulty, string type);
    Question? Add(Question question);
}