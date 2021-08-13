using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalityQuiz.Models
{
    public class QuizTakenRepository
    {
        CacheDB _inMemoryDB;

        public QuizTakenRepository()
        {
            _inMemoryDB = new CacheDB();
        }

        public void InsertQuizTaken(QuizTaken newQuizTaken)
        {
            _inMemoryDB.InsertQuizTaken(newQuizTaken);
        }

        public List<QuizTaken> GetByUserID(string userID)
        {
            return _inMemoryDB.GetQuizTakenTable().Where(x => x.UserID.Equals(userID)).ToList();
        }
    }
}