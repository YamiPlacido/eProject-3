using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using eProject3.Models;
using Newtonsoft.Json;

namespace eProject3.Areas.Admin.Controllers
{
    public class CoursesController : Controller
    {
        private eProject3Context db = new eProject3Context();
        public ActionResult Index()
        {
            if (Session["ADMIN_SESSION"] == null)
            {
                return RedirectToAction("Login", "Admins");
            }
            else
                return View();
        }

        //Get List Of Course
        public async Task<ActionResult> GetCourseList()
        {
            db.Configuration.LazyLoadingEnabled = false;
            List<Course> couList = await db.Courses.ToListAsync<Course>();
            return Json(new { data = couList }, JsonRequestBehavior.AllowGet);
        }

        //Get Course ID
        public async Task<JsonResult> GetCourseById(int CourseID)
        {
            Course co = await db.Courses.Where(x => x.CourseID == CourseID).SingleOrDefaultAsync();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(co, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        //Add and Save data to database
        public async Task<JsonResult> SaveData(Course course)
        {
            var result = false;
            try
            {
                string fileName = Path.GetFileNameWithoutExtension(course.ImageFile.FileName);
                string extension = Path.GetExtension(course.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                course.CourseImage = "/Images/CourseImage/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images/CourseImage/"), fileName);
                course.ImageFile.SaveAs(fileName);
                if (course.CourseID > 0)
                {
                    if (ModelState.IsValid)
                    {
                        db.Entry(course).State = EntityState.Modified;
                        await db.SaveChangesAsync();
                        result = true;
                    }
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        db.Courses.Add(course);
                        await db.SaveChangesAsync();
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //Delete
        public async Task<JsonResult> DeleteCourseRecord(int CourseID)
        {
            bool result = false;
            Course courses = await db.Courses.FindAsync(CourseID);
            if (courses != null)
            {
                db.Courses.Remove(courses);
                await db.SaveChangesAsync();
                result = true;
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
