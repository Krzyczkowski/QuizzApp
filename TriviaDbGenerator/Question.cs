using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TriviaDbGenerator
{
    class Question
    {
        public int Id { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("difficulty")]
        public string Difficulty { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("question")]
        public string QuestionText { get; set; }

        [JsonPropertyName("correct_answer")]
        public string CorrectAnswer { get; set; }

        [JsonPropertyName("incorrect_answers")]
        public List<string> IncorrectAnswers { get; set; }
        public Question(){}
        public Question(int id, string type, string difficulty, string category, string questionText, string correctAnswer, List<string> incorrectAnswers)
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
}
