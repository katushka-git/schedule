using System;
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
    public class ParasController : Controller
    {
        private ScheduleContex db = new ScheduleContex();
                    // GET: Orders
            public async Task<ActionResult> Index()
            {
                var paras = db.Paras.Include(o => o.Day);
                return View(await paras.ToListAsync());
            }

            // GET: Orders/Details/5
            public async Task<ActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Para para = await db.Paras.FindAsync(id);
                if (para == null)
                {
                    return HttpNotFound();
                }
                return View(para);
            }

            // GET: Orders/Create
            public ActionResult Create()
            {
                ViewBag.DayId = new SelectList(db.Days, "Id", "Name");
                return View();
            }

            // POST: Orders/Create
            // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
            // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<ActionResult> Create([Bind(Include = "Id,DayId, Number")] Para para)
            {
                if (ModelState.IsValid)
                {

                    db.Paras.Add(para);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }

                ViewBag.DayId = new SelectList(db.Days, "Id", "Name", para.DayId);

                return View(para);
            }

            // GET: Orders/Edit/5
            public async Task<ActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Para para = await db.Paras.FindAsync(id);
                if (para == null)
                {
                    return HttpNotFound();
                }
                ViewBag.DayId = new SelectList(db.Days, "Id", "Name", para.DayId);
                return View(para);
            }

            // POST: Orders/Edit/5
            // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
            // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<ActionResult> Edit([Bind(Include = "Id,DayId,Number")] Para para)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(para).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                ViewBag.DayId = new SelectList(db.Days, "Id", "FIO", para.DayId);
                return View(para);
            }

            // GET: Orders/Delete/5
            public async Task<ActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Para para = await db.Paras.FindAsync(id);
                if (para == null)
                {
                    return HttpNotFound();
                }
                return View(para);
            }

            // POST: Orders/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<ActionResult> DeleteConfirmed(int id)
            {
                Para para = await db.Paras.FindAsync(id);
                db.Paras.Remove(para);
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
