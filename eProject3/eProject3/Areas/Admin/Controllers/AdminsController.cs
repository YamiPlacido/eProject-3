using eProject3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eProject3.Areas.Admin.Controllers
{
    public class AdminsController : Controller
    {
        private eProject3Context db = new eProject3Context();
        // GET: Admin/Admins
        public ActionResult Index()
        {
            ViewBag.ClassCount = db.Classes.Count();
            ViewBag.StudentCount = db.Students.Count();
            ViewBag.CourseCount = db.Courses.Count();
            ViewBag.ExamCount = db.EntranceExams.Count();
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
    }
}