﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Schedule.Models;

namespace Schedule.Controllers
{
    public class ScheduleTablesController : Controller
    {
        private ScheduleContex db = new ScheduleContex();

        // GET: ScheduleTables
        public async Task<ActionResult> Index()
        {
            var shed = db.ScheduleTables.Include(x => x.Para).Include(x => x.Room).Include(x => x.Subject).Include(x => x.Group).Include(x => x.Teacher).Include(x => x.Day);
            return View(await shed.ToListAsync());
        }
        // GET: ScheduleTables/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleTable scheduleTable = await db.ScheduleTables.FindAsync(id);
            if (scheduleTable == null)
            {
                return HttpNotFound();
            }
            return View(scheduleTable);
        }
        // GET: ScheduleTables/Create
        public ActionResult Create()
        {
            ViewBag.DayId = new SelectList(db.Days, "Id", "Name");
            ViewBag.ParaId = new SelectList(db.Paras, "Id", "Number");
            ViewBag.RoomId = new SelectList(db.Rooms, "Id", "Number");
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "UPlanId");
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Number");
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "FIO");
            return View();
        }
        // POST: ScheduleTables/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,DayId, Name, ParaId, Number, RoomId,Number,SubjectId,UPlanId,GroupId,Number,TeacherId,FIO")] ScheduleTable scheduleTable)
        {
            if (ModelState.IsValid)
            {

                db.ScheduleTables.Add(scheduleTable);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.DayId = new SelectList(db.Days, "Id", "Name", scheduleTable.DayId);
            ViewBag.ParaId = new SelectList(db.Paras, "Id", "Number", scheduleTable.ParaId);
            ViewBag.RoomId = new SelectList(db.Rooms, "Id", "Number", scheduleTable.RoomId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "UPlanId", scheduleTable.SubjectId);
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Number", scheduleTable.GroupId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "FIO", scheduleTable.TeacherId);

            return View(scheduleTable);
        }
         public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleTable scheduleTable = await db.ScheduleTables.FindAsync(id); ;
            if (scheduleTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.DayId = new SelectList(db.Days, "Id", "Name", scheduleTable.DayId);
            ViewBag.ParaId = new SelectList(db.Paras, "Id", "Number", scheduleTable.ParaId);
            ViewBag.RoomId = new SelectList(db.Rooms, "Id", "Number", scheduleTable.RoomId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "UPlanId", scheduleTable.SubjectId);
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Number", scheduleTable.GroupId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "FIO", scheduleTable.TeacherId);
            return View(scheduleTable);
        }
        // POST: ScheduleTables/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public async Task<ActionResult> Edit([Bind(Include = "Id,DayId, Name, ParaId, Number, RoomId,Number,SubjectId,UPlanId,GroupId,Number,TeacherId,FIO")] ScheduleTable scheduleTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scheduleTable).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DayId = new SelectList(db.Days, "Id", "Name", scheduleTable.DayId);
            ViewBag.ParaId = new SelectList(db.Paras, "Id", "Number", scheduleTable.ParaId);
            ViewBag.RoomId = new SelectList(db.Rooms, "Id", "Number", scheduleTable.RoomId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "UPlanId", scheduleTable.SubjectId);
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Number", scheduleTable.GroupId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "FIO", scheduleTable.TeacherId);
            return View(scheduleTable);
        }
       
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleTable scheduleTable = await db.ScheduleTables.FindAsync(id);
            if (scheduleTable == null)
            {
                return HttpNotFound();
            }
            return View(scheduleTable);
        }
        // POST: ScheduleTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ScheduleTable scheduleTable = await db.ScheduleTables.FindAsync(id);
            db.ScheduleTables.Remove(scheduleTable);
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
