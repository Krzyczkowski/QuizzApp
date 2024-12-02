public record AddQuestionRequest(
    string? Category = "General Knowledge",
    string? Difficulty = "easy",
    string Type = "multiple",
    string QuestionText = "Question Text",
    string? CorrectAnswer = null,
    List<string>? IncorrectAnswers = null
);