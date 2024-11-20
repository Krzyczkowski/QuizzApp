public record QuestionRequest(
    string Category,
    string? Difficulty = null,
    string? Type = null
);