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
    public class ParasController : Controller
    {
        private ScheduleContex db = new ScheduleContex();

        // GET: Paras
        public ActionResult Index()
        {
            return View(db.Paras.ToList());
        }

        // GET: Paras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Para para = db.Paras.Find(id);
            if (para == null)
            {
                return HttpNotFound();
            }
            return View(para);
        }

        // GET: Paras/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Paras/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Number,DaysId")] Para para)
        {
            if (ModelState.IsValid)
            {
                db.Paras.Add(para);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(para);
        }

        // GET: Paras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Para para = db.Paras.Find(id);
            if (para == null)
            {
                return HttpNotFound();
            }
            return View(para);
        }

        // POST: Paras/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Number,DaysId")] Para para)
        {
            if (ModelState.IsValid)
            {
                db.Entry(para).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(para);
        }

        // GET: Paras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Para para = db.Paras.Find(id);
            if (para == null)
            {
                return HttpNotFound();
            }
            return View(para);
        }

        // POST: Paras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Para para = db.Paras.Find(id);
            db.Paras.Remove(para);
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
