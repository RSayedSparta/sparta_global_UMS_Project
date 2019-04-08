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
using UMS_Project.Controllers;

namespace UMS_Project.Controllers
{
    [AuthorizationFilter]
    public class CohortsController : Controller
    {
        private User_ManagementDBEntities db = new User_ManagementDBEntities();

        // GET: Cohorts
        public ActionResult Index(string sortOrder, string searchString)
        {

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "cohortName_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "startdate_desc" : "Date";
            ViewBag.DateSortParm = sortOrder == "Date" ? "enddate_desc" : "Date";
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "hasTA_desc" : "";
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "location_desc" : "";
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "maxCapacity_desc" : "";
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "MinCapacity_desc" : "";
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "streamName_desc" : "";
            var cohorts = from c in db.Cohorts
                        select c;
            if (!String.IsNullOrEmpty(searchString))
            {
                cohorts = cohorts.Where(c => c.cohortName.Contains(searchString));                       
            }

            switch (sortOrder)
            {
                case "cohortName_desc":
                    cohorts = cohorts.OrderByDescending(c => c.cohortName);
                    break;
                case "startdate_desc":
                    cohorts = cohorts.OrderBy(c => c.age);
                    break;
                case "enddate_desc":
                    cohorts = cohorts.OrderByDescending(u => u.lastName);
                    break;
                case "hasTA_desc":
                    cohorts = cohorts.OrderByDescending(u => u.gender);
                    break;
                case "location_desc":
                    cohorts = cohorts.OrderByDescending(u => u.email);
                    break;
                case "maxCapacity_desc":
                    cohorts = cohorts.OrderByDescending(u => u.cohortID);
                    break;
                case "MinCapacity_desc":
                    cohorts = cohorts.OrderByDescending(u => u.roleID);
                    break;
                case "streamName_desc:
                    users = users.OrderByDescending(u => u.roleID);
                    break;
                default:
                    users = users.OrderBy(u => u.firstName);
                    break;
            }

            var cohorts = db.Cohorts.Include(c => c.Stream);
            return View(cohorts.ToList());
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
