

using Microsoft.AspNetCore.Mvc;
using QuizzApp.Models;

public interface IAnswerController{
    ActionResult<IEnumerable<QuestionResponse>> getAnswers(QuestionRequest request);
    IActionResult addAnswer(AddQuestionRequest request);
}