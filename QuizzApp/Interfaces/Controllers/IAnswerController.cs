

using Microsoft.AspNetCore.Mvc;
using QuizzApp.Contracts.Answer;
using QuizzApp.Models;

public interface IAnswerController{
    ActionResult<AnswerResponse> getCorrectAnswers(QuestionRequest request);
    IActionResult addAnswer(AnswerRequest request);
}