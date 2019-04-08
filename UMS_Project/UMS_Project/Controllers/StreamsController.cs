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
    public class StreamsController : Controller
    {
       
        private User_ManagementDBEntities db = new User_ManagementDBEntities();

        public object Search_Data { get; private set; }
        public object Filter_Value { get; private set; }
        public int PageNo { get; private set; }

        // GET: Streams
        public ActionResult Index(string SortingOrder, string Search_Data, string Filter_Value, int? PageNo)
        {
            ViewBag.CurrentSort = SortingOrder;
            ViewBag.SortingName = String.IsNullOrEmpty(SortingOrder) ? "Name_Description" : "";
            ViewBag.SortingDuration = String.IsNullOrEmpty(SortingOrder) ? "Duration_Description" : "";

            if (Search_Data != null)
            {
                PageNo = 1;
            }
            else
            {
                Search_Data = Filter_Value;
            }

            ViewBag.FilterValue = Search_Data;

            var streams = from stream in db.Streams select stream;
            switch (SortingOrder)
            {
                case "Name_Description":
                    streams = streams.OrderByDescending(stream => stream.streamName);
                    break;
                case "Duration":
                    streams = streams.OrderBy(stream => stream.duration);
                    break;
                case "Specialisation":
                    streams = streams.OrderBy(stream => stream.specialization);
                    break;
                default:
                    streams = streams.OrderBy(stream => stream.curriculum);
                    break;
            }
            int Size_Of_Page = 10;
            int No_Of_Page = PageNo ?? 1;
            return View(streams.ToPagedList(No_Of_Page, Size_Of_Page));
            //return View(db.Roles.ToList());
            
        }
        // GET: Streams
        public ActionResult Streams()
        {
            return View();
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
            return View(stream);
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
