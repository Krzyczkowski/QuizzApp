using QuizzApp.Models;

public interface ICorrectAnswerRepository{
    CorrectAnswer? Add(CorrectAnswer correctAnswer);
}