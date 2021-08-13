using PersonalityQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalityQuiz.ViewModels
{
    public class HomeIndexViewModel
    {
        public Question TheQuestion { get; set; }
        public List<Answer> AnswesOptions { get; set; }
        public string UserID { get; set; }
        public int PreviousID { get; set; }
        public int TotalQuestions { get; set; }
        public int CurrentQuestionOrder { get; set; }
    }
}