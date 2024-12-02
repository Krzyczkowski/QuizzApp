using Microsoft.AspNetCore.Mvc;
using QuizzApp.Interfaces.Persistence;
using QuizzApp.Models;

public class QuestionService : IQuestionService
{
    private readonly IQuestionRepository _questionRepository;
    public QuestionService(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }
    public ActionResult<Question> AddQuestion(AddQuestionRequest request)
    {
        // Walidacja requestu
        if (request.Type != "multiple" && request.Type != "boolean")
            return new BadRequestObjectResult("Bad question type! Supporting only 'boolean' and 'multiple'");

        if (request.Difficulty != "easy" && request.Difficulty != "medium" && request.Difficulty != "hard")
            return new BadRequestObjectResult("Bad difficulty type! Supporting only 'easy', 'medium', and 'hard'");

        if (string.IsNullOrWhiteSpace(request.CorrectAnswer))
            return new BadRequestObjectResult("There is no correct answer in the request!");

        if (request.IncorrectAnswers is null || request.IncorrectAnswers.Count == 0)
            return new BadRequestObjectResult("There is no incorrect answer(s) in the request!");

        if (request.Type == "multiple" && request.IncorrectAnswers.Count != 3)
            return new BadRequestObjectResult("You should specify exactly 3 answers for a 'multiple' type question!");

        if (request.Type == "boolean" && request.IncorrectAnswers.Count != 1)
            return new BadRequestObjectResult("You should specify exactly 1 answer for a 'boolean' type question!");

        Question question = new Question(
            id: Guid.NewGuid(),
            type: request.Type,
            difficulty: request.Difficulty!,
            category: request.Category!,
            questionText: request.QuestionText,
            correctAnswer: request.CorrectAnswer!,
            incorrectAnswers: request.IncorrectAnswers!
        );

        var addedQuestion = _questionRepository.Add(question);

        if (addedQuestion == null) return new UnprocessableEntityObjectResult("Problem with saving Question in databse!");

        return new OkObjectResult(addedQuestion);
    }

    public ActionResult<IEnumerable<Question>> GetQuestions(QuestionRequest request)
    {
        if (request.Difficulty != "random" && request.Difficulty != "easy" && request.Difficulty != "medium" && request.Difficulty != "hard")
            return new BadRequestObjectResult("Bad difficulty type! Supporting only 'random', 'easy', 'medium', and 'hard'");
        if (request.Type != "random" && request.Type != "multiple" && request.Type != "boolean")
            return new BadRequestObjectResult("Bad question type! Supporting only 'boolean' and 'multiple'");
        if(request.Take<=0 || request.Take>10){
            return new BadRequestObjectResult("Take argument should be in range: <1,10>");
        }
        var questions = _questionRepository.Get(request.Category!, request.Difficulty!, request.Type!, request.Take);
        if (questions == null) 
            return new UnprocessableEntityObjectResult("Problem with saving Question in databse!");
        
        List<QuestionResponse> questionResponse= new List<QuestionResponse>();
        foreach(var question in questions){
            List<string> answers = new List<string>(question.IncorrectAnswers);
            answers.Add(question.CorrectAnswer);
            questionResponse.Add(new QuestionResponse(
                Id: question.Id,
                Category: question.Category,
                Difficulty: question.Difficulty,
                QuestionText: question.QuestionText,
                Answers: answers,
                Type: question.Type
            ));
        }
        
        return new OkObjectResult(questionResponse);
    }
}