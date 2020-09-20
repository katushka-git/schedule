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
    public class ScheduleTablesController : Controller
    {
        private ScheduleContex db = new ScheduleContex();

        // GET: ScheduleTables
        public ActionResult Index()
        {
            return View(db.ScheduleTables.ToList());
        }

        // GET: ScheduleTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleTable scheduleTable = db.ScheduleTables.Find(id);
            if (scheduleTable == null)
            {
                return HttpNotFound();
            }
            return View(scheduleTable);
        }

        // GET: ScheduleTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ScheduleTables/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CallSheduleId,ParaId,RoomId,SubjectId,GroupId,TeacherId")] ScheduleTable scheduleTable)
        {
            if (ModelState.IsValid)
            {
                db.ScheduleTables.Add(scheduleTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(scheduleTable);
        }

        // GET: ScheduleTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleTable scheduleTable = db.ScheduleTables.Find(id);
            if (scheduleTable == null)
            {
                return HttpNotFound();
            }
            return View(scheduleTable);
        }

        // POST: ScheduleTables/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CallSheduleId,ParaId,RoomId,SubjectId,GroupId,TeacherId")] ScheduleTable scheduleTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scheduleTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(scheduleTable);
        }

        // GET: ScheduleTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleTable scheduleTable = db.ScheduleTables.Find(id);
            if (scheduleTable == null)
            {
                return HttpNotFound();
            }
            return View(scheduleTable);
        }

        // POST: ScheduleTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ScheduleTable scheduleTable = db.ScheduleTables.Find(id);
            db.ScheduleTables.Remove(scheduleTable);
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
