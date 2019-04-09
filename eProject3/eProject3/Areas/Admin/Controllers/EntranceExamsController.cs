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
    public class EntranceExamsController : Controller
    {
        private eProject3Context db = new eProject3Context();

        // GET: Admin/EntranceExams
        public ActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetEntranceExamList()
        {
            List<EntranceExamDTO> ex = await db.EntranceExams.Select(x => new EntranceExamDTO
            {
                EntranceExamID = x.EntranceExamID,
                EntranceExamName = x.EntranceExamName,
                EntranceExamDescription = x.EntranceExamDescription,
                EntranceExamStartDate = x.EntranceExamStartDate.ToString()
            }).ToListAsync();

            return Json(ex, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> GetEntranceExamByID(int EntranceExamID)
        {
            EntranceExam ex = await db.EntranceExams.Where(x => x.EntranceExamID == EntranceExamID).SingleOrDefaultAsync();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(ex, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> SaveData([Bind(Include = "EntranceExamID,EntranceExamName,EntranceExamDescription,EntranceExamStartDate")] EntranceExam entranceExam)
        {
            var result = false;
            try
            {
                if(entranceExam.EntranceExamID > 0)
                {
                    if (ModelState.IsValid)
                    {
                        db.Entry(entranceExam).State = EntityState.Modified;
                        await db.SaveChangesAsync();
                        result = true;
                    }                
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        db.EntranceExams.Add(entranceExam);
                        await db.SaveChangesAsync();
                        result = true;
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> DeleteEntranceExam(int EntranceExamID)
        {
            bool result = false;
            EntranceExam ex = await db.EntranceExams.FindAsync(EntranceExamID);
            if(ex != null)
            {
                db.EntranceExams.Remove(ex);
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
