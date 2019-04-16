using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using eProject3.Models;
using Newtonsoft.Json;

namespace eProject3.Areas.Admin.Controllers
{
    public class CourseStudentsController : Controller
    {
        private eProject3Context db = new eProject3Context();
        // GET: Admin/CourseStudents
        public ActionResult Index()
        {
            if (Session["ADMIN_SESSION"] == null)
            {
                return RedirectToAction("Login", "Admins");
            }
            else
            {
                List<Student> stLst = db.Students.ToList();
                ViewBag.ListOfStudent = new SelectList(stLst, "StudentRoll", "StudentFirstName");
                List<Course> CoLst = db.Courses.ToList();
                ViewBag.ListOfCourse = new SelectList(CoLst, "CourseID", "CourseName");
                return View();
            }
        }

        public async Task<JsonResult> GetCourseStudentList()
        {
            List<CourseStudentDTO> rs = await db.CourseStudents.Select(x => new CourseStudentDTO
            {
                CourseID = x.CourseID,
                StudentRoll = x.StudentRoll,
                LabFee = x.LabFee
            }).ToListAsync();

            return Json(rs, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> GetCourseStudentByID(int CourseID, int StudentRoll)
        {
            CourseStudent ct = await db.CourseStudents.Where(x => x.CourseID == CourseID && x.StudentRoll == StudentRoll).SingleOrDefaultAsync();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(ct, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> SaveCreateData([Bind(Include = "CourseID,StudentRoll,LabFee")] CourseStudent courseStudent)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.CourseStudents.Add(courseStudent);
                    await db.SaveChangesAsync();
                    TempData["Message"] = "Success!";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Redirect(Request.UrlReferrer.ToString());
        }

        public async Task<ActionResult> SaveUpdateData([Bind(Include = "CourseID,StudentRoll,LabFee")] CourseStudent courseStudent)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(courseStudent).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    TempData["Message"] = "Success!";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Redirect(Request.UrlReferrer.ToString());
        }

        public async Task<JsonResult> DeleteCourseStudent(int CourseID, int StudentRoll)
        {
            bool result = false;
            CourseStudent rs = await db.CourseStudents.Where(x => x.StudentRoll == StudentRoll && x.CourseID == CourseID).SingleOrDefaultAsync();
            if (rs != null)
            {
                db.CourseStudents.Remove(rs);
                await db.SaveChangesAsync();
                result = true;
                TempData["Message"] = "Success!";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}