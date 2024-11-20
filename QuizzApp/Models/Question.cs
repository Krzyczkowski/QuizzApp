using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QuizzApp.Models;

public class Question
{
    public Guid Id { get; set; }
    public string Type { get; set; }
    public string Difficulty { get; set; }
    public string Category { get; set; }
    public string QuestionText { get; set; }
    public string CorrectAnswer { get; set; }
    public List<string> IncorrectAnswers { get; set; } = new();
    public Question(Guid id, string type, string difficulty, string category, string questionText, string correctAnswer, List<string> incorrectAnswers)
    {
        Id = id;
        Type = type;
        Difficulty = difficulty;
        Category = category;
        QuestionText = questionText;
        CorrectAnswer = correctAnswer;
        IncorrectAnswers = incorrectAnswers ?? new List<string>();
    }
}

