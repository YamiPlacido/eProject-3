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

namespace eProject3.Areas.Admin.Controllers
{
    public class StudentsController : Controller
    {
        private eProject3Context db = new eProject3Context();

        // GET: Admin/Students
        public ActionResult Index()
        {
            List<Class> ClassLst = db.Classes.ToList();
            ViewBag.ListOfClass = new SelectList(ClassLst, "ClassID", "ClassName");
            return View();
        }

        public async Task<JsonResult> GetStudentList()
        {
            List<StudentDTO> students = await db.Students.Select(x => new StudentDTO
            {
                StudentRoll = x.StudentRoll,
                StudentFirstName = x.StudentFirstName,
                StudentLastName = x.StudentLastName,
                ClassID = x.ClassID,
                StudentAddress = x.StudentAddress,
                StudentDOB = x.StudentDOB.ToString(),
                StudentEmail = x.StudentEmail,
                StudentResult = x.StudentResult
            }).ToListAsync();

            return Json(students, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> GetStudentByID(int StudentRoll)
        {
            Student st = await db.Students.Where(x => x.StudentRoll == StudentRoll).SingleOrDefaultAsync();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(st, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> SaveData([Bind(Include = "StudentRoll,StudentFirstName,StudentLastName,StudentAddress,StudentDOB,StudentEmail,StudentResult,ClassID")] Student student)
        {
            try
            {
                if(student.StudentRoll >0)
                {
                    if (ModelState.IsValid)
                    {
                        db.Entry(student).State = EntityState.Modified;
                        await db.SaveChangesAsync();
                        TempData["Message"] = "Success!";
                    }
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        db.Students.Add(student);
                        await db.SaveChangesAsync();
                        TempData["Message"] = "Success!";
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return Redirect(Request.UrlReferrer.ToString());
        }

        public async Task<JsonResult> DeleteStudent(int StudentRoll)
        {
            bool result = false;
            Student st = await db.Students.FindAsync(StudentRoll);
            if(st!= null)
            {
                db.Students.Remove(st);
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
