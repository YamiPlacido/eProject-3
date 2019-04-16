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
    public class ClassesController : Controller
    {
        private eProject3Context db = new eProject3Context();

        // GET: Admin/Classes
        public ActionResult Index()
        {
            if (Session["ADMIN_SESSION"] == null)
            {
                return RedirectToAction("Login", "Admins");
            }
            else
            {
                return View();
            }
        }

        public async Task<JsonResult> GetClassList()
        {
            List<ClassDTO> classes = await db.Classes.Select(x => new ClassDTO
            {
                ClassID = x.ClassID,
                ClassName = x.ClassName,
                ClassDescription = x.ClassDescription,
                ClassTuitionFee = x.ClassTuitionFee,
                ClassEstimatedDuration = x.ClassEstimatedDuration,
                ClassPaymentDeadline = x.ClassPaymentDeadline.ToString(),
                ClassStartDate = x.ClassStartDate.ToString(),
                ClassEndDate = x.ClassEndDate.ToString()
            }).ToListAsync();

            return Json(classes, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> GetClassByID(int ClassID)
        {
            Class model = await db.Classes.Where(x => x.ClassID == ClassID).SingleOrDefaultAsync();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> SaveData([Bind(Include = "ClassID,ClassName,ClassDescription,ClassTuitionFee,ClassPaymentDeadline,ClassEstimatedDuration,ClassStartDate,ClassEndDate")] Class @class)
        {
            try
            {
                if (@class.ClassID > 0)
                {
                    if (ModelState.IsValid)
                    {
                        db.Entry(@class).State = EntityState.Modified;
                        await db.SaveChangesAsync();
                        TempData["Message"] = "Success!";
                    }
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        db.Classes.Add(@class);
                        await db.SaveChangesAsync();
                        TempData["Message"] = "Success!";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Redirect(Request.UrlReferrer.ToString());
        }

        public async Task<JsonResult> DeleteClass(int ClassID)
        {
            bool result = false;
            Class @class = await db.Classes.FindAsync(ClassID);
            if(@class != null)
            {
                db.Classes.Remove(@class);
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
