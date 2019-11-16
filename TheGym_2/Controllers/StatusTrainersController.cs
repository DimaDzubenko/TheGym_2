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
    public class StatusTrainersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StatusTrainers
        public ActionResult Index()
        {
            return View(db.StatusTrainers.ToList());
        }

        // GET: StatusTrainers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusTrainer statusTrainer = db.StatusTrainers.Find(id);
            if (statusTrainer == null)
            {
                return HttpNotFound();
            }
            return View(statusTrainer);
        }

        // GET: StatusTrainers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StatusTrainers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title")] StatusTrainer statusTrainer)
        {
            if (ModelState.IsValid)
            {
                db.StatusTrainers.Add(statusTrainer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(statusTrainer);
        }

        // GET: StatusTrainers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusTrainer statusTrainer = db.StatusTrainers.Find(id);
            if (statusTrainer == null)
            {
                return HttpNotFound();
            }
            return View(statusTrainer);
        }

        // POST: StatusTrainers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title")] StatusTrainer statusTrainer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(statusTrainer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(statusTrainer);
        }

        // GET: StatusTrainers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusTrainer statusTrainer = db.StatusTrainers.Find(id);
            if (statusTrainer == null)
            {
                return HttpNotFound();
            }
            return View(statusTrainer);
        }

        // POST: StatusTrainers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StatusTrainer statusTrainer = db.StatusTrainers.Find(id);
            db.StatusTrainers.Remove(statusTrainer);
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
