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
    public class CallShedulesController : Controller
    {
        private ScheduleContex db = new ScheduleContex();

        // GET: CallShedules
        public ActionResult Index()
        {
            return View(db.CallShedules.ToList());
        }

        // GET: CallShedules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CallShedule callShedule = db.CallShedules.Find(id);
            if (callShedule == null)
            {
                return HttpNotFound();
            }
            return View(callShedule);
        }

        // GET: CallShedules/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CallShedules/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NamberPar,Start,Finish")] CallShedule callShedule)
        {
            if (ModelState.IsValid)
            {
                db.CallShedules.Add(callShedule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(callShedule);
        }

        // GET: CallShedules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CallShedule callShedule = db.CallShedules.Find(id);
            if (callShedule == null)
            {
                return HttpNotFound();
            }
            return View(callShedule);
        }

        // POST: CallShedules/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NamberPar,Start,Finish")] CallShedule callShedule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(callShedule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(callShedule);
        }

        // GET: CallShedules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CallShedule callShedule = db.CallShedules.Find(id);
            if (callShedule == null)
            {
                return HttpNotFound();
            }
            return View(callShedule);
        }

        // POST: CallShedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CallShedule callShedule = db.CallShedules.Find(id);
            db.CallShedules.Remove(callShedule);
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
