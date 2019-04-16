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
    public class AboutUssController : Controller
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

        //Get List Of Contact
        public async Task<ActionResult> GetAboutUsList()
        {
            db.Configuration.LazyLoadingEnabled = false;
            List<AboutUs> aboList = await db.AboutUss.ToListAsync<AboutUs>();
            return Json(new { data = aboList }, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> GetAboutUsById(int Aid)
        {
            AboutUs abou = await db.AboutUss.Where(x => x.Aid == Aid).SingleOrDefaultAsync();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(abou, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        //Add and Save data to database
        public async Task<ActionResult> SaveData([Bind(Include = "Aid, Aintroduction, Aservice")]AboutUs abou)
        {
            try
            {
                if (abou.Aid > 0)
                {
                    if (ModelState.IsValid)
                    {
                        db.Entry(abou).State = EntityState.Modified;
                        await db.SaveChangesAsync();
                        TempData["Message"] = "Sucess!";
                    }
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        db.AboutUss.Add(abou);
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
        public async Task<JsonResult> DeleteAboutUsRecord(int Aid)
        {
            var result = false;
            AboutUs abou = await db.AboutUss.FindAsync(Aid);
            if (abou != null)
            {
                db.AboutUss.Remove(abou);
                await db.SaveChangesAsync();
                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
