namespace QuizzApp.Contracts.Answer;
public record AnswerRequest(
    Guid QuestionId,
    string Answer
);