using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalityQuiz.Models
{
    public class UsersRepository
    {
        CacheDB _inMemoryDB;

        public UsersRepository()
        {
            _inMemoryDB = new CacheDB();
        }

        public void InsertUser(User newUser)
        {
            _inMemoryDB.InsertUser(newUser);
        }

        public User GetByID(string userID)
        {
            return _inMemoryDB.GetUsersTable().FirstOrDefault(x => x.UserID.Equals(userID));
        }
    }
}