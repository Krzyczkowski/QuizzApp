public record QuestionRequest(
    string? Category = "random",
    string? Difficulty = "random",
    string? Type = "random",
    int Take = 1
);