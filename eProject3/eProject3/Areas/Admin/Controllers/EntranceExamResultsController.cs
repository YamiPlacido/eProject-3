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
    public class EntranceExamResultsController : Controller
    {
        private eProject3Context db = new eProject3Context();

        // GET: Admin/EntranceExamResults
        public ActionResult Index()
        {
            List<Student> stLst = db.Students.ToList();
            ViewBag.ListOfStudent = new SelectList(stLst, "StudentRoll", "StudentFirstName");
            List<EntranceExam> ExLst = db.EntranceExams.ToList();
            ViewBag.ListOfEntranceExam = new SelectList(ExLst, "EntranceExamID", "EntranceExamName");
            return View();
        }

        public async Task<JsonResult> GetResultList()
        {
            List<EntranceExamResultDTO> rs = await db.EntranceExamResults.Select(x => new EntranceExamResultDTO
            {
                StudentRoll = x.StudentRoll,
                EntranceExamID = x.EntranceExamID,
                Mark = x.Mark
            }).ToListAsync();

            return Json(rs, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> GetResultListByID(int StudentRoll)
        {
            List<EntranceExamResultDTO> rs = await db.EntranceExamResults.Select(x => new EntranceExamResultDTO
            {
                StudentRoll = x.StudentRoll,
                EntranceExamID = x.EntranceExamID,
                Mark = x.Mark
            }).Where(x=>x.StudentRoll==StudentRoll).ToListAsync();

            return Json(rs, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> GetResultByID(int StudentRoll, int EntranceExamID)
        {
            EntranceExamResult st = await db.EntranceExamResults.Where(x => x.StudentRoll == StudentRoll && x.EntranceExamID == EntranceExamID).SingleOrDefaultAsync();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(st, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> SaveCreateData([Bind(Include = "StudentRoll,EntranceExamID,Mark")] EntranceExamResult entranceExamResult)
        {
            var result = false;
            try
            {
                if (ModelState.IsValid)
                {
                    db.EntranceExamResults.Add(entranceExamResult);
                    await db.SaveChangesAsync();
                    result = true;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> SaveUpdateData([Bind(Include = "StudentRoll,EntranceExamID,Mark")] EntranceExamResult entranceExamResult)
        {
            var result = false;
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(entranceExamResult).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> DeleteResult(int StudentRoll, int EntranceExamID)
        {
            bool result = false;
            EntranceExamResult rs = await db.EntranceExamResults.Where(x=>x.StudentRoll==StudentRoll&&x.EntranceExamID==EntranceExamID).SingleOrDefaultAsync();
            if (rs != null)
            {
                db.EntranceExamResults.Remove(rs);
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
