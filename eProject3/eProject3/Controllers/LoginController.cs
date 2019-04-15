using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eProject3.Common;
using eProject3.Functions;
using eProject3.Models;

namespace eProject3.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var f = new UserFunctions();
                var result = f.Login(model.UserName, model.Password);
                if (result == 1)
                {
                    var user = f.GetByID(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserFirstName = user.UserFirstName;
                    userSession.UserID = user.UserID;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    TempData["Message"] = "Welcome, "+userSession.UserFirstName+"!";
                    return Redirect(Request.UrlReferrer.ToString());
                }
                else if(result == -1)
                {
                    ModelState.AddModelError("", "Wrong password.");
                    TempData["Error"] = "Wrong password!";
                }
                else if(result == 0)
                {
                    ModelState.AddModelError("", "This account is not exist!");
                    TempData["Error"] = "This account is not exist!";
                }
                else
                {
                    ModelState.AddModelError("", "Log In error");
                    TempData["Error"] = "Log In error!";
                }
            }
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult Logout()
        {
            Session.Remove(CommonConstants.USER_SESSION);
            TempData["Message"] = "You have logged out!";
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}