public record QuestionResponse(
    Guid Id,
    string Category,
    string Difficulty,
    string QuestionText,
    List<string> Answers,
    string Type
);