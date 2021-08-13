using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalityQuiz.Models
{
    public class QuizTaken
    {
        public string UserID { get; set; }
        public int QuestionID { get; set; }
        public int AnswerID { get; set; }
    }
}