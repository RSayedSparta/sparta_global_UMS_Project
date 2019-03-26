﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UMS_Project;

namespace UMS_Project.Controllers
{
    public class StreamsController : Controller
    {
<<<<<<< HEAD
        private User_ManagementDBEntities1 db = new User_ManagementDBEntities1();
=======
        private User_ManagementDBEntities db = new User_ManagementDBEntities();
>>>>>>> 68d0b4dd81efab4b657501137fed4a4c4cc085f0

        // GET: Streams
        public ActionResult Index()
        {
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
