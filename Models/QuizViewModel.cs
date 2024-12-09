using System;
namespace MCQAssignment3.Models
{
    public class QuizViewModel
    {
        public List<Question> Questions { get; set; }
        public int CurrentQuestionIndex { get; set; }
        public int SelectedAnswer { get; set; } // The selected answer for the current question
    }

}

