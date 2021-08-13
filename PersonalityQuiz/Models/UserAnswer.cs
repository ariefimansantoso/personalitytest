using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalityQuiz.Models
{
    public class UserAnswer
    {
        public int ID { get; set; }
        public int QuizTakenID { get; set; }
        public Question TheQuestion { get; set; }
        public Answer SelectedAnswer { get; set; }
    }
}