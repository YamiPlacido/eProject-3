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

        public int Login(string userName,string passWord)
        {
            var result = db.Users.SingleOrDefault(x => x.UserName == userName);
            if (result == null)
            {
                return 0;
            }
            else if(result.UserPassword == passWord)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
}