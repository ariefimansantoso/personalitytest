using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalityQuiz.Models
{
    public class AnswersRepository
    {
        CacheDB _inMemoryDB;

        public AnswersRepository()
        {
            _inMemoryDB = new CacheDB();
        }

        public Answer GetByID(int id)
        {
            return _inMemoryDB.GetAnswersTable().FirstOrDefault(x => x.ID == id);
        }

        public List<Answer> GetByQuestionID(int questionId)
        {
            return _inMemoryDB.GetAnswersTable().Where(x => x.QuestionID == questionId).ToList();
        }
    }
}