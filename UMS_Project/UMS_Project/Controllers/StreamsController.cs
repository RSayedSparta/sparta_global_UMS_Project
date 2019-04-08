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

namespace UMS_Project.Controllers
{

    [AuthorizationFilter]
    public class StreamsController : Controller
    {
        private User_ManagementDBEntities db = new User_ManagementDBEntities();

        // GET: Streams
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "streamName_desc" : "";
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "specialization_desc" : "";
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "duration_desc" : "";
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "curriculum_desc" : "";
            var streams = from s in db.Streams
                        select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                streams = streams.Where(s => s.streamName.Contains(searchString)
                                       || s.specialization.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "streamName_desc":
                    streams = streams.OrderByDescending(s => s.streamName);
                    break;
                case "specialization_desc":
                    streams = streams.OrderBy(s => s.specialization);
                    break;
                case "duration_desc":
                    streams = streams.OrderByDescending(s => s.duration);
                    break;
                case "curriculum_desc":
                    streams = streams.OrderByDescending(s => s.curriculum);
                    break;
                default:
                    streams = streams.OrderBy(s => s.streamName);
                    break;
            }
            return View(db.Streams.ToList());
        }

        // GET: Streams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Stream stream = db.Streams.Find(id);
            //Stream stream = db.Streams.Single(s => s.streamName == streamName);

            if (stream == null)
            {
                return HttpNotFound();
            }
            return View("Details", stream);
        }

        // GET: Streams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Streams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "streamID,streamName,specialization,duration,curriculum")] Stream stream)
        {
            if (ModelState.IsValid)
            {
                db.Streams.Add(stream);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stream);
        }

        // GET: Streams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stream stream = db.Streams.Find(id);
            if (stream == null)
            {
                return HttpNotFound();
            }
            return View(stream);
        }

        // POST: Streams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "streamID,streamName,specialization,duration,curriculum")] Stream stream)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stream).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stream);
        }

        // GET: Streams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stream stream = db.Streams.Find(id);
            if (stream == null)
            {
                return HttpNotFound();
            }
            return View(stream);
        }

        // POST: Streams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stream stream = db.Streams.Find(id);
            db.Streams.Remove(stream);
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
