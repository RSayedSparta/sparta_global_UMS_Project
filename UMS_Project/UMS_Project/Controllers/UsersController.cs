using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using UMS_Project.AuthData;

namespace UMS_Project.Controllers
{
    public class UsersController : Controller
    {
        private User_ManagementDBEntities db = new User_ManagementDBEntities();

        // GET: Users
        [AuthorizationFilter]
        public ActionResult Index()
        {
            var users = db.Users.Include(u => u.Cohort).Include(u => u.Role);
            return View(users.ToList());
        }

        // GET: Users/Details/5
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

        // GET: Users/Create

        public ActionResult Create()
        {
            ViewBag.cohortID = new SelectList(db.Cohorts, "cohortID", "cohortName");
            ViewBag.roleID = new SelectList(db.Roles, "roleID", "roleName");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userID,firstName,lastName,age,gender,email,password,passwordSalt,passwordHash,roleID,cohortID")] User user)
        {

            string salt = PasswordSecurity.GenerateSalt(4);
            user.passwordSalt = salt;

            string hash = PasswordSecurity.GenerateHash(user.password, salt);
            user.passwordHash = hash;

            if(db.Users.Count(u => u.email == user.email) > 0)
            {
                return RedirectToAction("Create");
            }

            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login","Login");
            }

            ViewBag.cohortID = new SelectList(db.Cohorts, "cohortID", "cohortName", user.cohortID);
            ViewBag.roleID = new SelectList(db.Roles, "roleID", "roleName", user.roleID);
            return View(user);
        }

        // GET: Users/Edit/5
        
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

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userID,firstName,lastName,age,gender,email,password,passwordSalt,passwordHash,roleID,cohortID")] User user)
        {

            string salt = PasswordSecurity.GenerateSalt(4);
            user.passwordSalt = salt;

            string hash = PasswordSecurity.GenerateHash(user.password, salt);
            user.passwordHash = hash;

            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", user);
            }
            ViewBag.cohortID = new SelectList(db.Cohorts, "cohortID", "cohortName", user.cohortID);
            ViewBag.roleID = new SelectList(db.Roles, "roleID", "roleName", user.roleID);
            return View(user);
        }

        // GET: Users/Delete/5
        [AuthorizationFilter]
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

        // POST: Users/Delete/5
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
