using Microsoft.AspNetCore.Mvc;
using MCQAssignment3.Models;
using MCQAssignment3.Services;
using MCQAssignment3.Data;

namespace MCQAssignment3.Controllers
{

    public class QuizController : Controller
    {
        private readonly QuizContext _context;

        // Inject QuizContext into the controller
        public QuizController(QuizContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StartQuiz()
        {
            var questions = _context.Questions.ToList();
            var random = new Random();

            // Generating random 10 questions
            var randomQuestions = questions.OrderBy(q => random.Next()).Take(10).ToList();
            HttpContext.Session.Set("Questions", randomQuestions);
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

            // Passing the index and count information to the view
            ViewBag.CurrentQuestionIndex = currentQuestionIndex;
            ViewBag.TotalQuestions = questions.Count;

            // Retrieve the selected answer for this question
            var selectedAnswer = HttpContext.Session.GetSelectedAnswer(currentQuestionIndex);

            // Ensure selectedAnswer is safely retrieved (e.g., -1 if not set)
            int safeSelectedAnswer = selectedAnswer ?? -1; // Default value when null

            return View(new QuizViewModel
            {
                Questions = questions,
                CurrentQuestionIndex = currentQuestionIndex,
                SelectedAnswer = safeSelectedAnswer
            });
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

                // Storing the selected answer for this question
                HttpContext.Session.SetSelectedAnswer(currentQuestionIndex, selectedOption);

                // Checking if the selected answer is correct and updating the score
                if (selectedOption == currentQuestion.CorrectOption)
                {
                    score++; 
                }

                // Storing the updated score in session storage
                HttpContext.Session.SetInt32("Score", score);

                // next question
                HttpContext.Session.SetInt32("CurrentQuestion", currentQuestionIndex + 1);
            }

            return RedirectToAction("Question");
        }

        [HttpPost]
        public IActionResult GoBack()
        {
            var currentQuestionIndex = HttpContext.Session.GetInt32("CurrentQuestion") ?? 1;

            if (currentQuestionIndex > 0) 
            {
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

            // Creating a new Result object
            var result = new Result
            {
                Score = score,
                DateTime = DateTime.Now  // Set the current date and time
            };

            // Save the result to the database
            _context.Results.Add(result);
            _context.SaveChanges();

            ViewBag.Score = score;
            ViewBag.Message = message;

            HttpContext.Session.Clear();
            return View();
        }


        public IActionResult PastScores()
        {
            var scores = _context.Results.ToList();
            return View(scores);
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
