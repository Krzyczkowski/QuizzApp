using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net;
namespace TriviaDbGenerator
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task Main(string[] args)
        {
            string url = "https://opentdb.com/api.php?amount=50"; // URL API
            int numberOfRecords = 20000; // Liczba pytań do pobrania
            await Run(url, numberOfRecords);
        }


        public static async Task Run(string Url, int NumberOfRecords)
        {
            List<string> Database = new List<string>();
            await FetchQuestions(Database,Url,NumberOfRecords);

        }

        private static async Task FetchQuestions(List<string> Database, string Url, int NumberOfRecords)
        {
            var context = new TriviaDbContext();
            var existingQuestions = context.Question.ToDictionary(q => q.QuestionText);// Krok 1: Pobieram istniejące pytania
            var newQuestions = new List<Question>(); // Krok 2: Lista na nowe pytania
            int newRecords = 0;


            // tutaj glowna petla
            while (newRecords < NumberOfRecords) {
                string response = string.Empty;
                try
                {
                    response = await client.GetStringAsync(Url);
                }catch (Exception ex)
                {
                    Console.WriteLine($"Błąd podczas pobierania danych: {ex.Message}");
                    await Task.Delay(1000); 
                    continue; 
                }
                

                var jsonResponse = JsonSerializer.Deserialize<TriviaResponse>(response);
                if (jsonResponse != null && jsonResponse.ResponseCode==0)
                {
                    foreach (var question in jsonResponse.Results)
                    {

                        //czyszcznie danych poprzez HtmlDecode
                        question.QuestionText = WebUtility.HtmlDecode(question.QuestionText);
                        question.CorrectAnswer = WebUtility.HtmlDecode(question.CorrectAnswer);
                        question.Category = WebUtility.HtmlDecode(question.Category);
                        for (int i = 0; i < question.IncorrectAnswers.Count; i++)
                        {
                            question.IncorrectAnswers[i] = WebUtility.HtmlDecode(question.IncorrectAnswers[i]);
                        }
                        
                        var newQuestion = new Question
                        {
                            Category = question.Category,
                            Type = question.Type,
                            Difficulty = question.Difficulty,
                            QuestionText = question.QuestionText,
                            CorrectAnswer = question.CorrectAnswer,
                            IncorrectAnswers = question.IncorrectAnswers
                        };
                        if (!existingQuestions.ContainsKey(newQuestion.QuestionText))
                        {
                            newQuestions.Add(newQuestion);
                            existingQuestions[newQuestion.QuestionText] = newQuestion; // dodawanie do istniejących pytań
                        }
                    }
                    if (newQuestions.Count > 0)
                    {
                        context.Question.AddRange(newQuestions);
                        await context.SaveChangesAsync(); 
                        newRecords += newQuestions.Count;
                        newQuestions.Clear(); // czyszczenie listy
                    }
                    Console.WriteLine($"New records: {newRecords}");
                    await Task.Delay(6000);
                }
            }

        }
    }
}

// NIEWYDAJNE rozwiazanie:
// 1. sprawdzam czy Question istnieje w bazie,
// 2. dodaje Question do bazy,
// 3. zapisuje zmiany w context,
// 4. przechodze do nowego Question

// Nowe, optymalne rozwiazanie:
// 1. pobieram liste wszystkich Question z bazy i zapisuje do Dictionary, gdzie kluczem jest pytanie (tekst pytania)
// 2. Nowe Question dodaje do tymczasowej Listy pod warunkiem, że nie ma ich w Dictionary z kroku nr. 1
// 3. Dodaje masowo question z Listy do bazy danych i zapisuje JEDEN(!) raz zmiany w context
