namespace QuizzApp.Contracts.Answer;
public record AnswerResponse(
    bool IsCorrect,
    string CorrectAnswer,
    int PointsAwarded 
);