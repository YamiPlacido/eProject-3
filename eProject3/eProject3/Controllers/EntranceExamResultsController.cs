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

namespace eProject3.Controllers
{
    public class EntranceExamResultsController : Controller
    {
        private eProject3Context db = new eProject3Context();

        public async Task<JsonResult> GetResultByID(int StudentRoll)
        {
            EntranceExamResult st = await db.EntranceExamResults.Where(x => x.StudentRoll == StudentRoll).SingleOrDefaultAsync();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(st, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }
    }
}
