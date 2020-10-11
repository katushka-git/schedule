using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Schedule.Models;

namespace Schedule.Controllers
{
    public class UPlansController : Controller
    {
        private ScheduleContex db = new ScheduleContex();

        // GET: UPlans
        public ActionResult Index()
        {
            return View(db.UPlans.ToList());
        }

        // GET: UPlans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UPlan uPlan = db.UPlans.Find(id);
            if (uPlan == null)
            {
                return HttpNotFound();
            }
            return View(uPlan);
        }

        // GET: UPlans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UPlans/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Lecture,Control,Practical,Labor,Coursework,Exam,Zachet,Consultation")] UPlan uPlan)
        {
            if (ModelState.IsValid)
            {
                db.UPlans.Add(uPlan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uPlan);
        }

        // GET: UPlans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UPlan uPlan = db.UPlans.Find(id);
            if (uPlan == null)
            {
                return HttpNotFound();
            }
            return View(uPlan);
        }

        // POST: UPlans/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Lecture,Control,Practical,Labor,Coursework,Exam,Zachet,Consultation")] UPlan uPlan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uPlan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uPlan);
        }

        // GET: UPlans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UPlan uPlan = db.UPlans.Find(id);
            if (uPlan == null)
            {
                return HttpNotFound();
            }
            return View(uPlan);
        }

        // POST: UPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UPlan uPlan = db.UPlans.Find(id);
            db.UPlans.Remove(uPlan);
            db.SaveChanges();
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
