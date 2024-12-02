using Microsoft.AspNetCore.Mvc;
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

    [HttpGet]
    public ActionResult<QuestionResponse> getQuestion(QuestionRequest request)
    {
        throw new NotImplementedException();
    }
    [HttpGet]
    public ActionResult<IEnumerable<QuestionResponse>> getQuestions(QuestionRequest request)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    public IActionResult removeQuestion()
    {
        throw new NotImplementedException();
    }
}