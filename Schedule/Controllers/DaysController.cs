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
    public class DaysController : Controller
    {
        private ScheduleContex db = new ScheduleContex();

        // GET: Days
        public async Task<ActionResult> Index(int page = 1)
        {
            var days = db.Days.ToList();
            int pageSize = 3; // количество объектов на страницу
            IEnumerable<Day> clientPerPages = days.Skip((page - 1) * pageSize).Take(pageSize);
            //PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = clients.Count };
            //IndexViewModel2 ivm = new IndexViewModel2 { PageInfo = pageInfo, Client = clientPerPages };
            return View(days);
        }


        // GET: Clients/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Day day = await db.Days.FindAsync(id);
            if (day == null)
            {
                return HttpNotFound();
            }
            return View(day);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name")] Day day)
        {
            if (ModelState.IsValid)
            {
                db.Days.Add(day);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(day);
        }

        // GET: Clients/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Day day = await db.Days.FindAsync(id);
            if (day == null)
            {
                return HttpNotFound();
            }
            return View(day);
        }

        // POST: Clients/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] Day day)
        {
            if (ModelState.IsValid)
            {
                db.Entry(day).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(day);
        }

        // GET: Clients/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Day day = await db.Days.FindAsync(id);
            if (day == null)
            {
                return HttpNotFound();
            }
            return View(day);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Day day = await db.Days.FindAsync(id);
            db.Days.Remove(day);
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
