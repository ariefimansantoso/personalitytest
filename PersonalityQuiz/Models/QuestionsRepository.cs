using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalityQuiz.Models
{
    public class QuestionsRepository
    {
        CacheDB _inMemoryDB;

        public QuestionsRepository()
        {
            _inMemoryDB = new CacheDB();
        }

        public List<Question> GetAll()
        {
            return _inMemoryDB.GetQuestionsTable();
        }

        public Question GetByID(int id)
        {
            return _inMemoryDB.GetQuestionsTable().FirstOrDefault(x => x.ID == id);
        }

        public Question GetNext(int currentId)
        {
            var currentQuestion = _inMemoryDB.GetQuestionsTable().FirstOrDefault(x => x.ID == currentId);
            return _inMemoryDB.GetQuestionsTable().FirstOrDefault(x => x.QuestionOrder == (currentQuestion.QuestionOrder + 1));
        }

        public Question GetPrevious(int currentId)
        {
            var currentQuestion = _inMemoryDB.GetQuestionsTable().FirstOrDefault(x => x.ID == currentId);
            return _inMemoryDB.GetQuestionsTable().FirstOrDefault(x => x.QuestionOrder == (currentQuestion.QuestionOrder - 1));
        }

        public int GetTotalQuestion()
        {
            return _inMemoryDB.GetQuestionsTable().Count;
        }
    }
}