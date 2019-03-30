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
        public async Task<ActionResult> Index()
        {
            return View(await db.EntranceExams.ToListAsync());
        }

        // GET: EntranceExams/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntranceExam entranceExam = await db.EntranceExams.FindAsync(id);
            if (entranceExam == null)
            {
                return HttpNotFound();
            }
            return View(entranceExam);
        }

        // GET: EntranceExams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EntranceExams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "EntranceExamID,EntranceExamName,EntranceExamDescription,EntranceExamStartDate")] EntranceExam entranceExam)
        {
            if (ModelState.IsValid)
            {
                db.EntranceExams.Add(entranceExam);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(entranceExam);
        }

        // GET: EntranceExams/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntranceExam entranceExam = await db.EntranceExams.FindAsync(id);
            if (entranceExam == null)
            {
                return HttpNotFound();
            }
            return View(entranceExam);
        }

        // POST: EntranceExams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "EntranceExamID,EntranceExamName,EntranceExamDescription,EntranceExamStartDate")] EntranceExam entranceExam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entranceExam).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(entranceExam);
        }

        // GET: EntranceExams/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntranceExam entranceExam = await db.EntranceExams.FindAsync(id);
            if (entranceExam == null)
            {
                return HttpNotFound();
            }
            return View(entranceExam);
        }

        // POST: EntranceExams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            EntranceExam entranceExam = await db.EntranceExams.FindAsync(id);
            db.EntranceExams.Remove(entranceExam);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
