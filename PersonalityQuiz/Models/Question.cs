using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalityQuiz.Models
{
    public class Question
    {
        public int ID { get; set; }
        public string QuestionDescription { get; set; }
        public int QuestionOrder { get; set; }
    }
}