using Microsoft.AspNetCore.Mvc;
using QuizzApp.Contracts.Answer;
using QuizzApp.Models;

public interface IQuestionService{
    ActionResult<Question> AddQuestion(AddQuestionRequest request);
    ActionResult<IEnumerable<Question>> GetQuestions(QuestionRequest request);
    ActionResult<AnswerResponse> AddQuestionAnswer(AnswerRequest request);

}