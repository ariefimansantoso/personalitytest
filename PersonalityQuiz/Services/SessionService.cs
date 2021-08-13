using PersonalityQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalityQuiz.Services
{
    public class SessionService
    {
        public User GetCurrentUser()
        {
            User currentUser = HttpContext.Current.Session[Constants.CURRENTUSER_SESSION_KEY] as User;
            if (currentUser == null)
            {
                var userID = Guid.NewGuid().ToString();
                var userName = userID;

                currentUser = new User
                {
                    UserID = userID,
                    Name = userName
                };

                HttpContext.Current.Session[Constants.CURRENTUSER_SESSION_KEY] = currentUser;
            }

            return currentUser;
        }

        public object GetObject(string sessionName)
        {
            object theObject = HttpContext.Current.Session[sessionName];
            return theObject;
        }

        public void ClearSession(string sessionKey)
        {
            HttpContext.Current.Session[sessionKey] = null;
        }
    }
}