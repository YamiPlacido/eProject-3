using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using eProject3.Models;
using Newtonsoft.Json;

namespace eProject3.Areas.Admin.Controllers
{
    public class ContactUssController : Controller
    {
        private eProject3Context db = new eProject3Context();

        // GET: Admin/ContactUss
        public ActionResult Index()
        {
            if (Session["USER_SESSION"] == null)
            {
                return RedirectToAction("Login", "Admins");
            }
            else
                return View();
        }

        //Get List Of Contact
        public async Task<ActionResult> GetContactUsList()
        {
            db.Configuration.LazyLoadingEnabled = false;
            List<ContactUs> conList = await db.ContactUss.ToListAsync<ContactUs>();
            return Json(new { data = conList }, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> GetContactUsById(int Cid)
        {
            ContactUs cont = await db.ContactUss.Where(x => x.Cid == Cid).SingleOrDefaultAsync();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(cont, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        //Add and Save data to database
        public async Task<ActionResult> SaveData([Bind(Include = "Cid, Clocation,Caddress,Cemail")] ContactUs cont)
        {
            try
            {
                if (cont.Cid > 0)
                {
                    if (ModelState.IsValid)
                    {
                        db.Entry(cont).State = EntityState.Modified;
                        await db.SaveChangesAsync();
                        TempData["Message"] = "Sucess!";
                    }
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        db.ContactUss.Add(cont);
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
        public async Task<JsonResult> DeleteContactUsRecord(int Cid)
        {
            var result = false;
            ContactUs cont = await db.ContactUss.FindAsync(Cid);
            if (cont != null)
            {
                db.ContactUss.Remove(cont);
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
