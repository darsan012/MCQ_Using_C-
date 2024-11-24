using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace MCQAssignment3.Services
{
    public static class SessionExtension
    {
        // Sets a value in the session as a serialized JSON string
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        // Gets a value from the session by deserializing the JSON string
        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }

        // Store the selected answer for a specific question
        public static void SetSelectedAnswer(this ISession session, int questionIndex, int selectedAnswer)
        {
            var answers = session.Get<Dictionary<int, int>>("SelectedAnswers") ?? new Dictionary<int, int>();
            answers[questionIndex] = selectedAnswer;
            session.Set("SelectedAnswers", answers);
        }

        // Get the selected answer for a specific question
        public static int? GetSelectedAnswer(this ISession session, int questionIndex)
        {
            var answers = session.Get<Dictionary<int, int>>("SelectedAnswers");
            if (answers != null && answers.ContainsKey(questionIndex))
            {
                return answers[questionIndex];
            }
            return null; // No answer selected for this question
        }
    }
}
