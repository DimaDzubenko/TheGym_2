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
    public class TrainerSchedulesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TrainerSchedules
        public ActionResult Index()
        {
            var trainerSchedules = db.TrainerSchedules.Include(t => t.HallGym).Include(t => t.Trainer);
            return View(trainerSchedules.ToList());
        }

        // GET: TrainerSchedules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainerSchedule trainerSchedule = db.TrainerSchedules.Find(id);
            if (trainerSchedule == null)
            {
                return HttpNotFound();
            }
            return View(trainerSchedule);
        }

        // GET: TrainerSchedules/Create
        public ActionResult Create()
        {
            ViewBag.HallGymId = new SelectList(db.HallGyms, "Id", "Title");
            ViewBag.TrainerId = new SelectList(db.Trainers, "Id", "Id");
            return View();
        }

        // POST: TrainerSchedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StartWorkout,EndWorkout,TrainerId,HallGymId")] TrainerSchedule trainerSchedule)
        {
            if (ModelState.IsValid)
            {
                db.TrainerSchedules.Add(trainerSchedule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HallGymId = new SelectList(db.HallGyms, "Id", "Title", trainerSchedule.HallGymId);
            ViewBag.TrainerId = new SelectList(db.Trainers, "Id", "Id", trainerSchedule.TrainerId);
            return View(trainerSchedule);
        }

        // GET: TrainerSchedules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainerSchedule trainerSchedule = db.TrainerSchedules.Find(id);
            if (trainerSchedule == null)
            {
                return HttpNotFound();
            }
            ViewBag.HallGymId = new SelectList(db.HallGyms, "Id", "Title", trainerSchedule.HallGymId);
            ViewBag.TrainerId = new SelectList(db.Trainers, "Id", "Id", trainerSchedule.TrainerId);
            return View(trainerSchedule);
        }

        // POST: TrainerSchedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StartWorkout,EndWorkout,TrainerId,HallGymId")] TrainerSchedule trainerSchedule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainerSchedule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HallGymId = new SelectList(db.HallGyms, "Id", "Title", trainerSchedule.HallGymId);
            ViewBag.TrainerId = new SelectList(db.Trainers, "Id", "Id", trainerSchedule.TrainerId);
            return View(trainerSchedule);
        }

        // GET: TrainerSchedules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainerSchedule trainerSchedule = db.TrainerSchedules.Find(id);
            if (trainerSchedule == null)
            {
                return HttpNotFound();
            }
            return View(trainerSchedule);
        }

        // POST: TrainerSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrainerSchedule trainerSchedule = db.TrainerSchedules.Find(id);
            db.TrainerSchedules.Remove(trainerSchedule);
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
