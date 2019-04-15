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

namespace eProject3.Controllers
{
    public class EntranceExamsController : Controller
    {
        private eProject3Context db = new eProject3Context();

        // GET: EntranceExams
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
    }
}
