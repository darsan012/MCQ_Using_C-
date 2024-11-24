// File: Services/QuizService.cs
using MCQAssignment3.Models;
using System;
using System.Collections.Generic;

namespace MCQAssignment3.Services
{
    public class QuizService
    {
        private static readonly QuestionPool QuestionPool = new()
        {
            Questions = new List<Question>
            {
                new Question { Id = 1, Text = "What is the capital of France?", Options = new[] { "Paris", "Berlin", "Madrid", "Rome" }, CorrectOption = 0 },
                new Question { Id = 2, Text = "Which planet is known as the Red Planet?", Options = new[] { "Mars", "Earth", "Venus", "Jupiter" }, CorrectOption = 0 },
                new Question { Id = 3, Text = "What is the largest mammal?", Options = new[] { "Elephant", "Blue Whale", "Giraffe", "Rhino" }, CorrectOption = 1 },
                new Question { Id = 4, Text = "Who wrote 'Hamlet'?", Options = new[] { "Shakespeare", "Dickens", "Austen", "Hemingway" }, CorrectOption = 0 },
                new Question { Id = 5, Text = "What is the square root of 64?", Options = new[] { "6", "7", "8", "9" }, CorrectOption = 2 },
                new Question { Id = 6, Text = "Which element has the chemical symbol 'O'?", Options = new[] { "Gold", "Oxygen", "Osmium", "Helium" }, CorrectOption = 1 },
                new Question { Id = 7, Text = "What is the capital of Japan?", Options = new[] { "Beijing", "Seoul", "Bangkok", "Tokyo" }, CorrectOption = 3 },
                new Question { Id = 8, Text = "How many continents are there?", Options = new[] { "5", "6", "7", "8" }, CorrectOption = 2 },
                new Question { Id = 9, Text = "Who painted the Mona Lisa?", Options = new[] { "Van Gogh", "Da Vinci", "Picasso", "Rembrandt" }, CorrectOption = 1 },
                new Question { Id = 10, Text = "What is the boiling point of water?", Options = new[] { "90°C", "100°C", "110°C", "120°C" }, CorrectOption = 1 },
                new Question { Id = 11, Text = "What is the largest planet in our solar system?", Options = new[] { "Earth", "Mars", "Jupiter", "Saturn" }, CorrectOption = 2 },
                new Question { Id = 12, Text = "Which country is known as the Land of the Rising Sun?", Options = new[] { "China", "Japan", "India", "Thailand" }, CorrectOption = 1 },
                new Question { Id = 13, Text = "What is the chemical formula for water?", Options = new[] { "H2O", "CO2", "NaCl", "O2" }, CorrectOption = 0 },
                new Question { Id = 14, Text = "Which language is primarily spoken in Brazil?", Options = new[] { "Spanish", "French", "Portuguese", "English" }, CorrectOption = 2 },
                new Question { Id = 15, Text = "What is the capital of Italy?", Options = new[] { "Venice", "Milan", "Naples", "Rome" }, CorrectOption = 3 },
                new Question { Id = 16, Text = "What is 5 x 6?", Options = new[] { "28", "30", "32", "34" }, CorrectOption = 1 },
                new Question { Id = 17, Text = "What is the hardest natural substance?", Options = new[] { "Iron", "Gold", "Diamond", "Platinum" }, CorrectOption = 2 },
                new Question { Id = 18, Text = "What is the freezing point of water?", Options = new[] { "0°C", "32°C", "100°C", "-1°C" }, CorrectOption = 0 },
                new Question { Id = 19, Text = "What is the capital of Canada?", Options = new[] { "Toronto", "Vancouver", "Ottawa", "Montreal" }, CorrectOption = 2 },
                new Question { Id = 20, Text = "Who discovered gravity?", Options = new[] { "Newton", "Einstein", "Galileo", "Copernicus" }, CorrectOption = 0 },
            }
        };

        public List<Question> GetRandomQuestions(int count)
        {
            var random = new Random();
            var randomQuestions = new List<Question>();
            var questionIds = new HashSet<int>();

            while (randomQuestions.Count < count)
            {
                int index = random.Next(QuestionPool.Questions.Count);
                if (!questionIds.Contains(index))
                {
                    randomQuestions.Add(QuestionPool.Questions[index]);
                    questionIds.Add(index);
                }
            }

            return randomQuestions;
        }
    }
}
