using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UMS_Project;
using UMS_Project.AuthData;
using PagedList;

namespace UMS_Project.Controllers
{
    [AuthorizationFilter]
    public class TrainersController : Controller
    {
        private User_ManagementDBEntities db = new User_ManagementDBEntities();

        public int PageNo { get; private set; }

        // GET: Trainers
        public ActionResult Trainers(int? PageNo)
        {
            var trainers = db.Trainers.Include(t => t.Cohort).Include(t => t.User);
            return View(trainers.ToList());
        }
        int Size_Of_Page = 10;
        int No_Of_Page = PageNo ?? 1;
        return View(trainers.ToPagedList(No_Of_Page, Size_Of_Page));

        // GET: Trainers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer trainer = db.Trainers.Find(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        // GET: Trainers/Create
        public ActionResult Create()
        {
            ViewBag.cohortID = new SelectList(db.Cohorts, "cohortID", "cohortName");
            ViewBag.userID = new SelectList(db.Users, "userID", "firstName");
            return View();
        }

        // POST: Trainers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "trainerID,trainerName,userID,cohortID")] Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                db.Trainers.Add(trainer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cohortID = new SelectList(db.Cohorts, "cohortID", "cohortName", trainer.cohortID);
            ViewBag.userID = new SelectList(db.Users, "userID", "firstName", trainer.userID);
            return View(trainer);
        }

        // GET: Trainers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer trainer = db.Trainers.Find(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            ViewBag.cohortID = new SelectList(db.Cohorts, "cohortID", "cohortName", trainer.cohortID);
            ViewBag.userID = new SelectList(db.Users, "userID", "firstName", trainer.userID);
            return View(trainer);
        }

        // POST: Trainers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "trainerID,trainerName,userID,cohortID")] Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cohortID = new SelectList(db.Cohorts, "cohortID", "cohortName", trainer.cohortID);
            ViewBag.userID = new SelectList(db.Users, "userID", "firstName", trainer.userID);
            return View(trainer);
        }

        // GET: Trainers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer trainer = db.Trainers.Find(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        // POST: Trainers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trainer trainer = db.Trainers.Find(id);
            db.Trainers.Remove(trainer);
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
