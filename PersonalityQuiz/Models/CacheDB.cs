using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;

namespace PersonalityQuiz.Models
{
    public class CacheDB
    {
        public List<Question> GetQuestionsTable()
        {
            var questions = MemoryCache.Default[Constants.QUESTIONS_CACHE_KEY] as List<Question>;
            if (questions == null)
            {
                questions = QuizHelper.GenerateQuestions();
                MemoryCache.Default[Constants.QUESTIONS_CACHE_KEY] = questions;
            }

            return questions;
        }

        public List<Answer> GetAnswersTable()
        {
            var answers = MemoryCache.Default[Constants.ANSWERS_CACHE_KEY] as List<Answer>;
            if (answers == null)
            {
                answers = QuizHelper.GenerateAnswers();
                MemoryCache.Default[Constants.ANSWERS_CACHE_KEY] = answers;
            }

            return answers;
        }

        public void InsertUser(User newUser)
        {
            var users = MemoryCache.Default[Constants.USERS_CACHE_KEY] as List<User>;
            if (users == null)
            {
                users = new List<User>();
                users.Add(newUser);
                MemoryCache.Default[Constants.USERS_CACHE_KEY] = users;
            }
            else
            {
                if (!users.Contains(newUser))
                {
                    users.Add(newUser);
                    MemoryCache.Default[Constants.USERS_CACHE_KEY] = users;
                }
            }            
        }

        public List<User> GetUsersTable()
        {
            var users = MemoryCache.Default[Constants.USERS_CACHE_KEY] as List<User>;
            if (users == null)
            {
                users = new List<User>();
                MemoryCache.Default[Constants.USERS_CACHE_KEY] = users;
            }

            return users;
        }

        public void InsertQuizTaken(QuizTaken newQuizTaken)
        {
            var quizTakens = MemoryCache.Default[Constants.QUIZTAKEN_CACHE_KEY] as List<QuizTaken>;
            if (quizTakens == null)
            {
                quizTakens = new List<QuizTaken>();
                quizTakens.Add(newQuizTaken);
                MemoryCache.Default[Constants.QUIZTAKEN_CACHE_KEY] = quizTakens;
            }
            else
            {
                if (!quizTakens.Contains(newQuizTaken))
                {
                    quizTakens.Add(newQuizTaken);
                    MemoryCache.Default[Constants.QUIZTAKEN_CACHE_KEY] = quizTakens;
                }
            }
        }

        public List<QuizTaken> GetQuizTakenTable()
        {
            var quizTakens = MemoryCache.Default[Constants.QUIZTAKEN_CACHE_KEY] as List<QuizTaken>;
            if (quizTakens == null)
            {
                quizTakens = new List<QuizTaken>();
                MemoryCache.Default[Constants.QUIZTAKEN_CACHE_KEY] = quizTakens;
            }

            return quizTakens;
        }
    }


    public class QuizHelper
    {
        public static List<Question> GenerateQuestions()
        {
            List<Question> questions = new List<Question>();
            questions.Add(new Question
            {
                ID = 1,
                QuestionDescription = "You're really busy at work and a colleague is telling you their life story and personal woes. You",
                QuestionOrder = 1
            });
            questions.Add(new Question
            {
                ID = 2,
                QuestionDescription = "You've been sitting in the doctor's waiting room for more than 25 minutes. You",
                QuestionOrder = 2
            });
            questions.Add(new Question
            {
                ID = 3,
                QuestionDescription = "You're having an animated discussion with a colleague regarding a project that you're in charge of. You",
                QuestionOrder = 3
            });
            questions.Add(new Question
            {
                ID = 4,
                QuestionDescription = "You are taking part in a guided tour of a museum. You",
                QuestionOrder = 4
            });
            questions.Add(new Question
            {
                ID = 5,
                QuestionDescription = "During dinner parties at your home, you have a hard time with people who",
                QuestionOrder = 5
            });
            questions.Add(new Question
            {
                ID = 6,
                QuestionDescription = "Your friend ask you to order pizza. You",
                QuestionOrder = 6
            });

            return questions;
        }

        public static List<Answer> GenerateAnswers()
        {
            List<Answer> answers = new List<Answer>();
            answers.Add(new Answer
            {
                ID = 1,
                QuestionID = 5,
                AnswerText = "Ask you to tell a story in front of everyone else",
                AnswerScore = 10
            });
            answers.Add(new Answer
            {
                ID = 2,
                QuestionID = 5,
                AnswerText = "Talk privately between themselves",
                AnswerScore = 30
            });
            answers.Add(new Answer
            {
                ID = 3,
                QuestionID = 5,
                AnswerText = "Hang around you all evening",
                AnswerScore = 10
            });
            answers.Add(new Answer
            {
                ID = 4,
                QuestionID = 5,
                AnswerText = "Always drag the conversation back to themselves",
                AnswerScore = 30
            });


            answers.Add(new Answer
            {
                ID = 5,
                QuestionID = 4,
                AnswerText = "Are a bit too far towards the back so don't really hear what the guide is saying",
                AnswerScore = 10
            });
            answers.Add(new Answer
            {
                ID = 6,
                QuestionID = 4,
                AnswerText = "Follow the group without question",
                AnswerScore = 10
            });
            answers.Add(new Answer
            {
                ID = 7,
                QuestionID = 4,
                AnswerText = "Make sure that everyone is able to hear properly",
                AnswerScore = 30
            });
            answers.Add(new Answer
            {
                ID = 8,
                QuestionID = 4,
                AnswerText = "Are right up the front, adding your own comments in a loud voice",
                AnswerScore = 40
            });


            answers.Add(new Answer
            {
                ID = 9,
                QuestionID = 3,
                AnswerText = "Don't dare contradict them",
                AnswerScore = 10
            });
            answers.Add(new Answer
            {
                ID = 10,
                QuestionID = 3,
                AnswerText = "Think that they are obviously right",
                AnswerScore = 10
            });
            answers.Add(new Answer
            {
                ID = 11,
                QuestionID = 3,
                AnswerText = "Defend your own point of view, tooth and nail",
                AnswerScore = 30
            });
            answers.Add(new Answer
            {
                ID = 12,
                QuestionID = 3,
                AnswerText = "Continuously interrupt your colleague",
                AnswerScore = 40
            });


            answers.Add(new Answer
            {
                ID = 13,
                QuestionID = 2,
                AnswerText = "Look at your watch every two minutes",
                AnswerScore = 10
            });
            answers.Add(new Answer
            {
                ID = 14,
                QuestionID = 2,
                AnswerText = "Bubble with inner anger, but keep quiet",
                AnswerScore = 10
            });
            answers.Add(new Answer
            {
                ID = 15,
                QuestionID = 2,
                AnswerText = "Explain to other equally impatient people in the room that the doctor is always running late",
                AnswerScore = 30
            });
            answers.Add(new Answer
            {
                ID = 16,
                QuestionID = 2,
                AnswerText = "Complain in a loud voice, while tapping your foot impatiently",
                AnswerScore = 40
            });


            answers.Add(new Answer
            {
                ID = 17,
                QuestionID = 1,
                AnswerText = "Don't dare to interrupt them",
                AnswerScore = 10
            });
            answers.Add(new Answer
            {
                ID = 18,
                QuestionID = 1,
                AnswerText = "Think it's more important to give them some of your time; work can wait",
                AnswerScore = 10
            });
            answers.Add(new Answer
            {
                ID = 19,
                QuestionID = 1,
                AnswerText = "Listen, but with only with half an ear",
                AnswerScore = 30
            });
            answers.Add(new Answer
            {
                ID = 20,
                QuestionID = 1,
                AnswerText = "Interrupt and explain that you are really busy at the moment",
                AnswerScore = 40
            });


            answers.Add(new Answer
            {
                ID = 21,
                QuestionID = 6,
                AnswerText = "Ask them what toppings do they want",
                AnswerScore = 10
            });
            answers.Add(new Answer
            {
                ID = 22,
                QuestionID = 6,
                AnswerText = "order Large Pepperoni Pizza",
                AnswerScore = 30
            });
            answers.Add(new Answer
            {
                ID = 23,
                QuestionID = 6,
                AnswerText = "order Regular Margherita Pizza",
                AnswerScore = 10
            });
            answers.Add(new Answer
            {
                ID = 24,
                QuestionID = 6,
                AnswerText = "order Large Quattro Formagi",
                AnswerScore = 40
            });
            return answers;
        }
    }
}