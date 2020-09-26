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
    public class PositionsController : Controller
    {
        private ScheduleContex db = new ScheduleContex();

        public async Task<ActionResult> Index(int page = 1)
        {
            var positions = db.Positions.ToList();
            int pageSize = 3; // количество объектов на страницу
            //IEnumerable<Department> clientPerPages = positions.Skip((page - 1) * pageSize).Take(pageSize);
            //PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = clients.Count };
            //IndexViewModel2 ivm = new IndexViewModel2 { PageInfo = pageInfo, Client = clientPerPages };
            return View(positions);
        }


        // GET: Clients/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Position positions = await db.Positions.FindAsync(id);
            if (positions == null)
            {
                return HttpNotFound();
            }
            return View(positions);
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
        public async Task<ActionResult> Create([Bind(Include = "Id,Name")] Position position)
        {
            if (ModelState.IsValid)
            {
                db.Positions.Add(position);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(position);
        }

        // GET: Clients/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           Position position = await db.Positions.FindAsync(id);
            if (position == null)
            {
                return HttpNotFound();
            }
            return View(position);
        }

        // POST: Clients/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] Position position)
        {
            if (ModelState.IsValid)
            {
                db.Entry(position).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(position);
        }

        // GET: Clients/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Position position = await db.Positions.FindAsync(id);
            if (position == null)
            {
                return HttpNotFound();
            }
            return View(position);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Position position = await db.Positions.FindAsync(id);
            db.Positions.Remove(position);
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
