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
    public class LoginController : Controller
    {
        private User_ManagementDBEntities db = new User_ManagementDBEntities();

        // GET: Login
        public ActionResult Index()
        {
            var users = db.Users.Include(u => u.Cohort).Include(u => u.Role);
            return View(users.ToList());
        }
        //GET: Login
        public ActionResult Login()
        {
            return View();
        }
        //POST: Login
        [HttpPost]
        public ActionResult Login(User user)
        {

            User usr = db.Users.SingleOrDefault(u => u.email.Equals(user.email) && u.upassword.Equals(user.upassword));
            if (usr == null)
            {
                return RedirectToAction("Create", "Users");
            }
            else
            {
                Session["Email"] = usr.email;
                Session["Name"] = usr.firstName;
                Session["Role"] = usr.roleID;
                if (Session["Role"].ToString() == "1")
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    Session["userID"] = usr.userID;
                    return RedirectToAction("Details", "Users", user);
                }
                //return RedirectToAction("Index", "Home");
            }
        }
        // GET: Login/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            ViewBag.cohortID = new SelectList(db.Cohorts, "cohortID", "cohortName");
            ViewBag.roleID = new SelectList(db.Roles, "roleID", "roleName");
            return View();
        }

        // POST: Login/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userID,firstName,lastName,age,gender,email,upassword,passwordSalt,passwordHash,roleID,cohortID")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cohortID = new SelectList(db.Cohorts, "cohortID", "cohortName", user.cohortID);
            ViewBag.roleID = new SelectList(db.Roles, "roleID", "roleName", user.roleID);
            return View(user);
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.cohortID = new SelectList(db.Cohorts, "cohortID", "cohortName", user.cohortID);
            ViewBag.roleID = new SelectList(db.Roles, "roleID", "roleName", user.roleID);
            return View(user);
        }

        // POST: Login/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userID,firstName,lastName,age,gender,email,upassword,passwordSalt,passwordHash,roleID,cohortID")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cohortID = new SelectList(db.Cohorts, "cohortID", "cohortName", user.cohortID);
            ViewBag.roleID = new SelectList(db.Roles, "roleID", "roleName", user.roleID);
            return View(user);
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Login/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
