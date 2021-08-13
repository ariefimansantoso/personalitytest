using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalityQuiz.Models
{
    public class ScoreLevel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int MinScore { get; set; }
        public int MaxScore { get; set; }
    }
}