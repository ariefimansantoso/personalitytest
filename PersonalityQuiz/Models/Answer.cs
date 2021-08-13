namespace PersonalityQuiz.Models
{
    public class Answer
    {
        public int ID { get; set; }
        public string AnswerText { get; set; }
        public int AnswerScore   { get; set; }
        public int QuestionID { get; set; }
    }
}