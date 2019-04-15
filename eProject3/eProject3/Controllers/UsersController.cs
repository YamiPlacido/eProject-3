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

        public async Task<JsonResult> SaveData([Bind(Include = "UserID,UserName,UserPassword,UserFirstName,UserLastName,UserAddress,UserDOB,UserEmail,GroupID")] User user)
        {
            user.GroupID = "USER";
            var result = false;
            try
            {
                if (ModelState.IsValid)
                {
                    db.Users.Add(user);
                    await db.SaveChangesAsync();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
