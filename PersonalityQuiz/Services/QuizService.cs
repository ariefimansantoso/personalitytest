using PersonalityQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalityQuiz.Services
{
    public class QuizService
    {
        QuizTakenRepository _quizTakenRepository;
        SessionService _sessionService;
        QuestionsRepository _questionsRepository;
        AnswersRepository _answersRepository;

        public QuizService()
        {
            _quizTakenRepository = new QuizTakenRepository();
            _sessionService = new SessionService();
            _questionsRepository = new QuestionsRepository();
            _answersRepository = new AnswersRepository();
        }

        public string GetResult()
        {
            string currentUserId = _sessionService.GetCurrentUser().UserID;
            var quizTaken = _quizTakenRepository.GetByUserID(currentUserId);

            int totalScore = 0;

            foreach(var item in quizTaken)
            {
                var answerScore = _answersRepository.GetByID(item.AnswerID).AnswerScore;
                totalScore = totalScore + answerScore;
            }

            if(totalScore <= 60)
            {
                return "Introvert";
            }

            return "Extrovert";
        }
    }
}