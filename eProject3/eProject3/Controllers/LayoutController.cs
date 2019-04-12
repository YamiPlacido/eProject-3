using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eProject3.Controllers
{
    public class LayoutController : Controller
    {
        public ActionResult _Register()
        {
            return PartialView("_Register");
        }

        public ActionResult _Login()
        {
            return PartialView("_Login");
        }

        public ActionResult _Logout()
        {
            return PartialView("_Logout");
        }
    }
}