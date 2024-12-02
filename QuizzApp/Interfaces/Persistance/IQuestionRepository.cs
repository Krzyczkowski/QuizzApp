using QuizzApp.Models;
namespace QuizzApp.Interfaces.Persistence;
public interface IQuestionRepository
{
    IEnumerable<Question>? Get(string category, string difficulty, string type, int take);
    Question? Add(Question question);
    Question? GetById(Guid id);
}