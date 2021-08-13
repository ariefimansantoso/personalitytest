using PersonalityQuiz.Models;
using PersonalityQuiz.Services;
using PersonalityQuiz.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalityQuiz.Controllers
{
    public class HomeController : Controller
    {
        QuestionsRepository _questionsRepository;
        AnswersRepository _answersRepository;
        QuizTakenRepository _quizTakenRepository;
        SessionService _sessionService;
        QuizService _quizService;

        public int TotalQuestions
        {
            get
            {
                return _questionsRepository.GetTotalQuestion();
            }
        }

        public HomeController()
        {
            _questionsRepository = new QuestionsRepository();
            _answersRepository = new AnswersRepository();
            _quizTakenRepository = new QuizTakenRepository();
            _sessionService = new SessionService();
            _quizService = new QuizService();
        }

        public ActionResult Index()
        {
            HomeIndexViewModel viewModel = new HomeIndexViewModel();
            
            var firstQuestion = _questionsRepository.GetByID(1);
            var answerOptions = _answersRepository.GetByQuestionID(firstQuestion.ID);

            viewModel.TheQuestion = firstQuestion;
            viewModel.AnswesOptions = answerOptions;
            viewModel.UserID = _sessionService.GetCurrentUser().UserID;
            viewModel.PreviousID = -99;
            viewModel.CurrentQuestionOrder = firstQuestion.QuestionOrder;
            viewModel.TotalQuestions = TotalQuestions;

            return View(viewModel);
        }

        public ActionResult Page(int id)
        {
            if(id == 1)
            {
                return RedirectToAction("Index");
            }

            HomeIndexViewModel viewModel = new HomeIndexViewModel();

            var firstQuestion = _questionsRepository.GetByID(id);
            var answerOptions = _answersRepository.GetByQuestionID(firstQuestion.ID);

            viewModel.TheQuestion = firstQuestion;
            viewModel.AnswesOptions = answerOptions;
            viewModel.UserID = _sessionService.GetCurrentUser().UserID;
            viewModel.CurrentQuestionOrder = firstQuestion.QuestionOrder;
            viewModel.TotalQuestions = TotalQuestions;

            var previousQuestion = _questionsRepository.GetPrevious(id);
            viewModel.PreviousID = previousQuestion != null ? previousQuestion.ID : -99;

            return View("Index", viewModel);
        }

        [HttpPost]
        public ActionResult Next(PostNextViewModel viewModel)
        {
            if (ModelState.IsValid && viewModel.AnswerID != 0)
            {                
                var quizTaken = new QuizTaken();
                quizTaken.UserID = _sessionService.GetCurrentUser().UserID;
                quizTaken.AnswerID = viewModel.AnswerID;
                quizTaken.QuestionID = viewModel.QuestionID;
                var currentUserAnswers = _quizTakenRepository.GetByUserID(_sessionService.GetCurrentUser().UserID);
                var existingAnswer = currentUserAnswers.FirstOrDefault(y => y.QuestionID == viewModel.QuestionID);
                if (existingAnswer != null)
                {
                    // user is going previous step and attempting to select another answer
                    existingAnswer.AnswerID = viewModel.AnswerID;
                }
                else
                {
                    _quizTakenRepository.InsertQuizTaken(quizTaken);
                }

                var totalQuestions = _questionsRepository.GetTotalQuestion();
                var totalQuizTaken = _quizTakenRepository.GetByUserID(_sessionService.GetCurrentUser().UserID).Count;

                if (totalQuizTaken < totalQuestions)
                {
                    var nextQuestion = _questionsRepository.GetNext(viewModel.QuestionID);
                    return RedirectToAction("Page", new { id = nextQuestion.ID });
                }
                else
                {
                    //finished
                    return RedirectToAction("Final");
                }
            }

            return RedirectToAction("Page", new { id = viewModel.QuestionID });
        }

        public ActionResult Final()
        {
            string result = _quizService.GetResult();
            var totalQuestions = _questionsRepository.GetTotalQuestion();
            var lastQuestion = _questionsRepository.GetAll().Where(s => s.QuestionOrder == totalQuestions).FirstOrDefault();
            var lastAnswerID = _quizTakenRepository.GetByUserID(_sessionService.GetCurrentUser().UserID).FirstOrDefault(s => s.QuestionID == lastQuestion.ID).AnswerID;
            var lastAnswer = _answersRepository.GetByID(lastAnswerID).AnswerText;

            string pizzaComment = "Wow, you are really introvert.";
            switch(lastAnswer)
            {
                case "Ask them what toppings do they want":
                    break;
                case "order Large Pepperoni Pizza":
                    pizzaComment = "And you love pepperoni so much.";
                    break;
                case "order Regular Margherita Pizza":
                    pizzaComment = "And you love a simple and classic pizza.";
                    break;
                case "order Large Quattro Formagi":
                    pizzaComment = "And you really love cheese.";
                    break;
            }

            FinalViewModel viewModel = new FinalViewModel();
            viewModel.Result = result;
            viewModel.PizzaComment = pizzaComment;

            _sessionService.ClearSession(Constants.CURRENTUSER_SESSION_KEY);

            return View(viewModel);
        }
    }
}