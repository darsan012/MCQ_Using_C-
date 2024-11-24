namespace MCQAssignment3.Models
{
    public class Question
    {
        public int Id { get; set; }
        public required string Text { get; set; }
        public required string[] Options { get; set; }
        public int CorrectOption { get; set; }

     }

    public class QuestionPool
    {
        public List<Question> Questions { get; set; } = new List<Question>();

        public List<Question> GetRandomQuestions(int count)
        {
            var random = new Random();
            return Questions.OrderBy(q => random.Next()).Take(count).ToList();
        }
    }
}
