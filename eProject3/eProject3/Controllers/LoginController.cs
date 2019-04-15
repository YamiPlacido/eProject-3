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
                if (result)
                {
                    var user = f.GetByID(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserFirstName = user.UserFirstName;
                    userSession.UserID = user.UserID;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    //return Redirect(Request.UrlReferrer.ToString());
                    return Redirect(Request.UrlReferrer.ToString());

                }
                else
                {
                    ModelState.AddModelError("", "Wrong username or password.");
                }
            }
            //return Redirect(Request.UrlReferrer.ToString());
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult Logout()
        {
            Session.Remove(CommonConstants.USER_SESSION);
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}