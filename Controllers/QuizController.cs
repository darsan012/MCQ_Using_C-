using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MCQAssignment3.Models;
using MCQAssignment3.Services;

namespace MCQAssignment3.Controllers
{

    public class QuizController : Controller
    {
        private readonly QuizService _quizService;

        // Inject QuizService into the controller
        public QuizController(QuizService quizService)
        {
            _quizService = quizService;
        }
      

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StartQuiz()
        {
            var selectedQuestions = _quizService.GetRandomQuestions(10);
            HttpContext.Session.Set("Questions", selectedQuestions);
            HttpContext.Session.SetInt32("CurrentQuestion", 0);
            HttpContext.Session.SetInt32("Score", 0);

            return RedirectToAction("Question");
        }

        public IActionResult Question()
        {
            var questions = HttpContext.Session.Get<List<Question>>("Questions");
            var currentQuestionIndex = HttpContext.Session.GetInt32("CurrentQuestion") ?? 0;

            if (questions == null || currentQuestionIndex >= questions.Count)
            {
                return RedirectToAction("Result");
            }

            var currentQuestion = questions[currentQuestionIndex];
            ViewBag.CurrentQuestionIndex = currentQuestionIndex + 1; // 1-based index
            ViewBag.TotalQuestions = questions.Count;

            // Retrieve the selected answer for this question
            var selectedAnswer = HttpContext.Session.GetSelectedAnswer(currentQuestionIndex);

            // Pass the selected answer to the view
            ViewBag.SelectedAnswer = selectedAnswer;

            return View(currentQuestion);
        }



        [HttpPost]
        public IActionResult Answer(int selectedOption)
        {
            var questions = HttpContext.Session.Get<List<Question>>("Questions");
            var currentQuestionIndex = HttpContext.Session.GetInt32("CurrentQuestion") ?? 0;
            var score = HttpContext.Session.GetInt32("Score") ?? 0;

            if (questions != null && currentQuestionIndex < questions.Count)
            {
                var currentQuestion = questions[currentQuestionIndex];

                // Store the selected answer for this question
                HttpContext.Session.SetSelectedAnswer(currentQuestionIndex, selectedOption);

                // Check if the selected answer is correct and update the score
                if (selectedOption == currentQuestion.CorrectOption)
                {
                    score++;  // Increment score if the answer is correct
                }

                // Store the updated score in session
                HttpContext.Session.SetInt32("Score", score);

                // Move to the next question
                HttpContext.Session.SetInt32("CurrentQuestion", currentQuestionIndex + 1);
            }

            return RedirectToAction("Question");
        }


        [HttpPost]
        public IActionResult GoBack()
        {
            var currentQuestionIndex = HttpContext.Session.GetInt32("CurrentQuestion") ?? 1;

            if (currentQuestionIndex >= 1)
            {
                // Decrease the current question index to go backward
                HttpContext.Session.SetInt32("CurrentQuestion", currentQuestionIndex - 1);
            }

            return RedirectToAction("Question");
        }

        public IActionResult Result()
        {
            var score = HttpContext.Session.GetInt32("Score") ?? 0;
            var message = score >= 8
                ? "You have successfully passed the test."
                : "Unfortunately you did not pass the test. Please try again later!";

            ViewBag.Score = score;
            ViewBag.Message = message;
            HttpContext.Session.Clear();
            return View();
        }
    }

    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, System.Text.Json.JsonSerializer.Serialize(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : System.Text.Json.JsonSerializer.Deserialize<T>(value);
        }
    }
}
