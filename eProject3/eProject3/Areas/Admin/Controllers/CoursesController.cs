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
using Newtonsoft.Json;
using System.IO;

namespace eProject3.Areas.Admin.Controllers
{
    public class CoursesController : Controller
    {
        private eProject3Context db = new eProject3Context();

        // GET: Admin/Courses
        public ActionResult Index()
        {
            return View();
        }

        // Get Course List
        public JsonResult GetCourseList()
        {
            //Pass The All Student Record From Controller To View For Show The All Data For User
            List<CourseDTO> CouList = db.Courses.Select(x => new CourseDTO
            {
                CourseID = x.CourseID,
                CourseName = x.CourseName,
                CourseDesctiption = x.CourseDesctiption,
                CourseDuration = x.CourseDuration,
                CourseStartDate = x.CourseStartDate.ToString(),
                CourseEndDate = x.CourseEndDate.ToString(),
                CourseImage = x.CourseImage
            }).ToList();

            return Json(CouList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCourseById(int CourseId)
        {
            Course model = db.Courses.Where(x => x.CourseID == CourseId).SingleOrDefault();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> SaveData([Bind(Include = "CourseID,CourseName,CourseDesctiption,CourseDuration,CourseStartDate,CourseEndDate,CourseImage,ImageFile")] Course course)
        {
            var result = false;
            try
            {
                //string fileName = Path.GetFileNameWithoutExtension(course.ImageFile.FileName);
                //string extension = Path.GetExtension(course.ImageFile.FileName);
                //fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                //course.CourseImage = "~/Images/CourseImage/" + fileName;
                //fileName = Path.Combine(Server.MapPath("~/Images/CourseImage/"), fileName);
                //course.ImageFile.SaveAs(fileName);
                if (course.CourseID > 0)
                {
                        string fileName = Path.GetFileNameWithoutExtension(course.ImageFile.FileName);
                        string extension = Path.GetExtension(course.ImageFile.FileName);
                        fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                        course.CourseImage = "~/Images/CourseImage/" + fileName;
                        fileName = Path.Combine(Server.MapPath("~/Images/CourseImage/"), fileName);
                        course.ImageFile.SaveAs(fileName);
                        db.Entry(course).State = EntityState.Modified;
                        await db.SaveChangesAsync();
                        result = true;
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

        // Delete
        public async Task<JsonResult> DeleteStudentRecord(int CourseId)
        {
            bool result = false;
            Course cou = await db.Courses.FindAsync(CourseId);
            if (cou != null)
            {
                db.Courses.Remove(cou);
                db.SaveChanges();
                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
