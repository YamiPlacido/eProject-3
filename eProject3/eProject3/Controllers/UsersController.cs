using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eProject3.Models;

namespace eProject3.Controllers
{
    public class UsersController : Controller
    {
        private eProject3Context db = new eProject3Context();

        public async Task<ActionResult> SaveData([Bind(Include = "UserID,UserName,UserPassword,UserFirstName,UserLastName,UserAddress,UserDOB,UserEmail,GroupID")] User user)
        {
            user.GroupID = "USER";
            try
            {
                if (ModelState.IsValid)
                {
                    db.Users.Add(user);
                    await db.SaveChangesAsync();
                    TempData["Message"] = "You account is registered successfully!";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}
