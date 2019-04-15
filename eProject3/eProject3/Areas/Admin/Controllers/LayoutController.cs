using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eProject3.Areas.Admin.Controllers
{
    public class LayoutController : Controller
    {
        // GET: Admin/Layout
        public ActionResult Admin_Logout()
        {
            return PartialView("_Logout");
        }
    }
}