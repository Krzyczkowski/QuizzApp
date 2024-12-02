

using Microsoft.AspNetCore.Mvc;
using QuizzApp.Models;

public interface IQuestionController{
    ActionResult<IEnumerable<QuestionResponse>> getQuestions(QuestionRequest request);
    IActionResult addQuestion(AddQuestionRequest request);
    IActionResult removeQuestion();
}