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

        public ActionResult Index(string sortOrder, string SearchData)
        {

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "cohortName_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "startdate_desc" : "Date";
            ViewBag.DateSortParm = sortOrder == "Date" ? "enddate_desc" : "Date";
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "hasTA_desc" : "";
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "location_desc" : "";
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "maxCapacity_desc" : "";
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "MinCapacity_desc" : "";
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "streamName_desc" : "";

            var cohort = from c in db.Cohorts
                         select c;
            if (!String.IsNullOrEmpty(SearchData))
            {
                cohort = cohort.Where(c => c.cohortName.ToUpper().Contains(SearchData.ToUpper()));
            }

            switch (sortOrder)
            {
                case "cohortName_desc":
                    cohort = cohort.OrderByDescending(c => c.cohortName);
                    break;
                case "startdate_desc":
                    cohort = cohort.OrderBy(c => c.startDate);
                    break;
                case "enddate_desc":
                    cohort = cohort.OrderByDescending(c => c.endDate);
                    break;
                case "hasTA_desc":
                    cohort = cohort.OrderByDescending(c => c.hasTA);
                    break;
                case "location_desc":
                    cohort = cohort.OrderByDescending(c => c.clocation);
                    break;
                case "maxCapacity_desc":
                    cohort = cohort.OrderByDescending(c => c.maximumSeats);
                    break;
                case "MinCapacity_desc":
                    cohort = cohort.OrderByDescending(c => c.minimumSeats);
                    break;
                case "streamName_desc":
                    cohort = cohort.OrderByDescending(c => c.streamID);
                    break;
                default:
                    cohort = cohort.OrderBy(c => c.cohortName);
                    break;
            }

            var cohorts = db.Cohorts.Include(c => c.Stream).Include(c => c.Trainers);
            return View(cohorts.ToList());
        }
            //public ActionResult Index(int? id)
            //{
            //    if (id == null)
            //    {
            //        var cohorts = db.Cohorts.Include(c => c.Stream).Include(c => c.Trainers);
            //        return View(cohorts.ToList());
            //    }
            //    else
            //    {
            //        var cohorts = db.Cohorts.Where(c => c.Stream.streamID == id).Include(c => c.Trainers);
            //        return View(cohorts.ToList());
            //    }


            //}

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
