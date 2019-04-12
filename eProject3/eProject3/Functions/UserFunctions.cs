using eProject3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eProject3.Functions
{
    public class UserFunctions
    {
        private eProject3Context db = new eProject3Context();

        public User GetByID(string userName)
        {
            return db.Users.SingleOrDefault(x => x.UserName == userName);
        }

        public bool Login(string userName,string passWord)
        {
            var result = db.Users.Count(x => x.UserName == userName && x.UserPassword == passWord);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}