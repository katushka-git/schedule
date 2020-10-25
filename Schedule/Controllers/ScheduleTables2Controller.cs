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
    public class ScheduleTables2Controller : Controller
    {
        private ScheduleContex db = new ScheduleContex();

        // GET: ScheduleTables2
        public ActionResult Index()
        {
            var scheduleTables = db.ScheduleTables.Include(s => s.CallShedule).Include(s => s.Day).Include(s => s.Group).Include(s => s.Para).Include(s => s.Room).Include(s => s.Subject).Include(s => s.Teacher);
            return View(scheduleTables.ToList());
        }

        // GET: ScheduleTables2/Details/5
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

        // GET: ScheduleTables2/Create
        public ActionResult Create()
        {
            ViewBag.CallSheduleId = new SelectList(db.CallShedules, "Id", "Id");
            ViewBag.DayId = new SelectList(db.Days, "Id", "Name");
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Specialty");
            ViewBag.ParaId = new SelectList(db.Paras, "Id", "Id");
            ViewBag.RoomId = new SelectList(db.Rooms, "Id", "Id");
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Id");
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "FIO");
            return View();
        }

        // POST: ScheduleTables2/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DayId,CallSheduleId,ParaId,RoomId,SubjectId,GroupId,TeacherId")] ScheduleTable scheduleTable)
        {
            if (ModelState.IsValid)
            {
                db.ScheduleTables.Add(scheduleTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CallSheduleId = new SelectList(db.CallShedules, "Id", "Id", scheduleTable.CallSheduleId);
            ViewBag.DayId = new SelectList(db.Days, "Id", "Name", scheduleTable.DayId);
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Specialty", scheduleTable.GroupId);
            ViewBag.ParaId = new SelectList(db.Paras, "Id", "Id", scheduleTable.ParaId);
            ViewBag.RoomId = new SelectList(db.Rooms, "Id", "Id", scheduleTable.RoomId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Id", scheduleTable.SubjectId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "FIO", scheduleTable.TeacherId);
            return View(scheduleTable);
        }

        // GET: ScheduleTables2/Edit/5
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
            ViewBag.CallSheduleId = new SelectList(db.CallShedules, "Id", "Id", scheduleTable.CallSheduleId);
            ViewBag.DayId = new SelectList(db.Days, "Id", "Name", scheduleTable.DayId);
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Specialty", scheduleTable.GroupId);
            ViewBag.ParaId = new SelectList(db.Paras, "Id", "Id", scheduleTable.ParaId);
            ViewBag.RoomId = new SelectList(db.Rooms, "Id", "Id", scheduleTable.RoomId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Id", scheduleTable.SubjectId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "FIO", scheduleTable.TeacherId);
            return View(scheduleTable);
        }

        // POST: ScheduleTables2/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DayId,CallSheduleId,ParaId,RoomId,SubjectId,GroupId,TeacherId")] ScheduleTable scheduleTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scheduleTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CallSheduleId = new SelectList(db.CallShedules, "Id", "Id", scheduleTable.CallSheduleId);
            ViewBag.DayId = new SelectList(db.Days, "Id", "Name", scheduleTable.DayId);
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Specialty", scheduleTable.GroupId);
            ViewBag.ParaId = new SelectList(db.Paras, "Id", "Id", scheduleTable.ParaId);
            ViewBag.RoomId = new SelectList(db.Rooms, "Id", "Id", scheduleTable.RoomId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Id", scheduleTable.SubjectId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "FIO", scheduleTable.TeacherId);
            return View(scheduleTable);
        }

        // GET: ScheduleTables2/Delete/5
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

        // POST: ScheduleTables2/Delete/5
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
