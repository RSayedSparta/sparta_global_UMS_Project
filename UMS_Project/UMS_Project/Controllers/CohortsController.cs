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
    public class CohortsController : Controller
    {
        private User_ManagementDBEntities db = new User_ManagementDBEntities();

       
        // GET: Cohorts
        public ActionResult Index(int? PageNo)
        {
            var cohorts = db.Cohorts.Include(c => c.Stream);
            return View(cohorts.ToList());
            int Size_Of_Page = 10;
            int No_Of_Page = PageNo ?? 1;
            return View(cohorts.ToPagedList(No_Of_Page, Size_Of_Page));
        }
       

        // GET: Cohorts
        public ActionResult Cohorts()
        {
            return View();
        }

        // GET: Cohorts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cohort cohort = db.Cohorts.Find(id);
            if (cohort == null)
            {
                return HttpNotFound();
            }
            return View(cohort);
        }

        // GET: Cohorts/Create
        public ActionResult Create()
        {
            ViewBag.streamID = new SelectList(db.Streams, "streamID", "streamName");
            return View();
        }

        // POST: Cohorts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cohortID,cohortName,startDate,endDate,hasTA,clocation,maximumSeats,minimumSeats,streamID")] Cohort cohort)
        {
            if (ModelState.IsValid)
            {
                db.Cohorts.Add(cohort);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.streamID = new SelectList(db.Streams, "streamID", "streamName", cohort.streamID);
            return View(cohort);
        }

        // GET: Cohorts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cohort cohort = db.Cohorts.Find(id);
            if (cohort == null)
            {
                return HttpNotFound();
            }
            ViewBag.streamID = new SelectList(db.Streams, "streamID", "streamName", cohort.streamID);
            return View(cohort);
        }

        // POST: Cohorts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cohortID,cohortName,startDate,endDate,hasTA,clocation,maximumSeats,minimumSeats,streamID")] Cohort cohort)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cohort).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.streamID = new SelectList(db.Streams, "streamID", "streamName", cohort.streamID);
            return View(cohort);
        }

        // GET: Cohorts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cohort cohort = db.Cohorts.Find(id);
            if (cohort == null)
            {
                return HttpNotFound();
            }
            return View(cohort);
        }

        // POST: Cohorts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cohort cohort = db.Cohorts.Find(id);
            db.Cohorts.Remove(cohort);
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
