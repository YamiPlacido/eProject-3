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
    public class FAQsController : Controller
    {
        private eProject3Context db = new eProject3Context();

        public ActionResult Index()
        {
            if (Session["USER_SESSION"] == null)
            {
                return RedirectToAction("Login", "Admins");
            }
            else
                return View();
        }

        //Get List Of FAQ
        public async Task<ActionResult> GetFaqList()
        {
            db.Configuration.LazyLoadingEnabled = false;
            List<FAQ> faqList = await db.FAQs.ToListAsync<FAQ>();
            return Json(new { data = faqList }, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> GetFaqById(int Fid)
        {
            FAQ fa = await db.FAQs.Where(x => x.Fid == Fid).SingleOrDefaultAsync();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(fa, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        //Add and Save data to database
        public async Task<ActionResult> SaveData([Bind(Include = "Fid,Fquestion,Fanswer")]FAQ faq)
        {
            try
            {
                if (faq.Fid > 0)
                {
                    if (ModelState.IsValid)
                    {
                        db.Entry(faq).State = EntityState.Modified;
                        await db.SaveChangesAsync();
                        TempData["Message"] = "Sucess!";
                    }
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        db.FAQs.Add(faq);
                        await db.SaveChangesAsync();
                        TempData["Message"] = "Sucess!";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Redirect(Request.UrlReferrer.ToString());
        }

        //Delete
        public async Task<JsonResult> DeleteFaqRecord(int Fid)
        {
            var result = "Failed";
            FAQ faq = await db.FAQs.FindAsync(Fid);
            if (faq != null)
            {
                db.FAQs.Remove(faq);
                await db.SaveChangesAsync();
                result = "Success!";
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
