using Microsoft.AspNetCore.Mvc;
using QuizzApp.Contracts.Answer;
[ApiController]
[Route("api/question")]
public class QuestionController : ControllerBase,IQuestionController
{
    private readonly IQuestionService _questionService;
    public QuestionController(IQuestionService questionService){
        _questionService = questionService;
    }


    [HttpPost]
    public IActionResult addQuestion(AddQuestionRequest request)
    {
        var result =_questionService.AddQuestion(request);
        if(result.Result is OkObjectResult)
            return Ok(result.Result);
        return BadRequest(result.Result);
    }

    [HttpPost("answer")]
    public IActionResult addQuestionAnswer(AnswerRequest request)
    {
        var result =_questionService.AddQuestionAnswer(request);
        if(result.Result is OkObjectResult)
            return Ok(result.Result);
        return BadRequest(result.Result);
    }

    [HttpGet]
    public ActionResult<IEnumerable<QuestionResponse>> getQuestions(QuestionRequest request)
    {
        var result =_questionService.GetQuestions(request);
        if(result.Result is OkObjectResult)
            return Ok(result.Result);
        return BadRequest(result.Result);
    }

    [HttpDelete]
    public IActionResult removeQuestion()
    {
        throw new NotImplementedException();
    }
}