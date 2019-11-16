using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheGym_2.Models;

namespace TheGym_2.Controllers
{
    public class StatusAdministratorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StatusAdministrators
        public ActionResult Index()
        {
            return View(db.StatusAdministrators.ToList());
        }

        // GET: StatusAdministrators/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusAdministrator statusAdministrator = db.StatusAdministrators.Find(id);
            if (statusAdministrator == null)
            {
                return HttpNotFound();
            }
            return View(statusAdministrator);
        }

        // GET: StatusAdministrators/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StatusAdministrators/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title")] StatusAdministrator statusAdministrator)
        {
            if (ModelState.IsValid)
            {
                db.StatusAdministrators.Add(statusAdministrator);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(statusAdministrator);
        }

        // GET: StatusAdministrators/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusAdministrator statusAdministrator = db.StatusAdministrators.Find(id);
            if (statusAdministrator == null)
            {
                return HttpNotFound();
            }
            return View(statusAdministrator);
        }

        // POST: StatusAdministrators/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title")] StatusAdministrator statusAdministrator)
        {
            if (ModelState.IsValid)
            {
                db.Entry(statusAdministrator).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(statusAdministrator);
        }

        // GET: StatusAdministrators/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusAdministrator statusAdministrator = db.StatusAdministrators.Find(id);
            if (statusAdministrator == null)
            {
                return HttpNotFound();
            }
            return View(statusAdministrator);
        }

        // POST: StatusAdministrators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StatusAdministrator statusAdministrator = db.StatusAdministrators.Find(id);
            db.StatusAdministrators.Remove(statusAdministrator);
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
