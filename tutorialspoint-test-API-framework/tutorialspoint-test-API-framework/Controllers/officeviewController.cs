using System;
using System.Collections.Generic;
using System.Data;


using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using tutorialspoint_test_API_framework.Data;
using tutorialspoint_test_API_framework.Models;

namespace tutorialspoint_test_API_framework.Controllers
{
    public class officeviewController : Controller
    {
        private tutorialspoint_test_API_frameworkContext db = new tutorialspoint_test_API_frameworkContext();
        int page_size = 5;

        // GET: officeview
        public async Task<ActionResult> Index(int page = 0)
        {
            var offices = db.offices.Include(a => a.emp).OrderBy(a => a.location).Skip(page * page_size).Take(page_size);
            return View(await offices.ToListAsync());
        }

        // GET: officeview/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            office office = await db.offices.FindAsync(id);
            if (office == null)
            {
                return HttpNotFound();
            }
            return View(office);
        }

        // GET: officeview/Create
        public ActionResult Create()
        {
            ViewBag.employeeID = new SelectList(db.employees, "ID", "name");
            return View();
        }

        // POST: officeview/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,location,employeeID")] office office)
        {
            if (ModelState.IsValid)
            {
                db.offices.Add(office);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.employeeID = new SelectList(db.employees, "ID", "name", office.employeeID);
            return View(office);
        }

        // GET: officeview/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            office office = await db.offices.FindAsync(id);
            if (office == null)
            {
                return HttpNotFound();
            }
            ViewBag.employeeID = new SelectList(db.employees, "ID", "name", office.employeeID);
            return View(office);
        }

        // POST: officeview/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,location,employeeID")] office office)
        {
            if (ModelState.IsValid)
            {
                db.Entry(office).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.employeeID = new SelectList(db.employees, "ID", "name", office.employeeID);
            return View(office);
        }

        // GET: officeview/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            office office = await db.offices.FindAsync(id);
            if (office == null)
            {
                return HttpNotFound();
            }
            return View(office);
        }

        // POST: officeview/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            office office = await db.offices.FindAsync(id);
            db.offices.Remove(office);
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
