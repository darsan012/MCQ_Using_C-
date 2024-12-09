namespace MCQAssignment3.Models
{
    public class Question
    {
        public int Id { get; set; }
        public required string Text { get; set; }
        public required string[] Options { get; set; }
        public int CorrectOption { get; set; }

     }
}
