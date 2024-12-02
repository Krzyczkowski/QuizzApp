using Microsoft.AspNetCore.Mvc;
using QuizzApp.Models;

public interface IQuestionService{
    ActionResult<Question> AddQuestion(AddQuestionRequest request);
    ActionResult<Question> GetQuestion(QuestionRequest request);

}