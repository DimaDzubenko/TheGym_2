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
    public class HallGymsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: HallGyms
        public ActionResult Index()
        {
            return View(db.HallGyms.ToList());
        }

        // GET: HallGyms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HallGym hallGym = db.HallGyms.Find(id);
            if (hallGym == null)
            {
                return HttpNotFound();
            }
            return View(hallGym);
        }

        // GET: HallGyms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HallGyms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title")] HallGym hallGym)
        {
            if (ModelState.IsValid)
            {
                db.HallGyms.Add(hallGym);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hallGym);
        }

        // GET: HallGyms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HallGym hallGym = db.HallGyms.Find(id);
            if (hallGym == null)
            {
                return HttpNotFound();
            }
            return View(hallGym);
        }

        // POST: HallGyms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title")] HallGym hallGym)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hallGym).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hallGym);
        }

        // GET: HallGyms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HallGym hallGym = db.HallGyms.Find(id);
            if (hallGym == null)
            {
                return HttpNotFound();
            }
            return View(hallGym);
        }

        // POST: HallGyms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HallGym hallGym = db.HallGyms.Find(id);
            db.HallGyms.Remove(hallGym);
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
