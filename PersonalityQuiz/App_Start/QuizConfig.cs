using PersonalityQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;

namespace PersonalityQuiz
{
    public class QuizConfig
    {
        public static void PopulateQuiz()
        {
            var questions = QuizHelper.GenerateQuestions();
            MemoryCache.Default[Constants.QUESTIONS_CACHE_KEY] = questions;

            var answers = QuizHelper.GenerateAnswers();
            MemoryCache.Default[Constants.ANSWERS_CACHE_KEY] = answers;
        }
    }
}