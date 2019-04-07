using System;
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
    public class DeletedUsersController : Controller
    {
        private User_ManagementDBEntities db = new User_ManagementDBEntities();

        // GET: DeletedUsers
        public ActionResult Index()
        {
            return View(db.DeletedUsers.ToList());
        }

        // GET: DeletedUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeletedUser deletedUser = db.DeletedUsers.Find(id);
            if (deletedUser == null)
            {
                return HttpNotFound();
            }
            return View(deletedUser);
        }

        // GET: DeletedUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeletedUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,userID,firstName,lastName,age,gender,email,passwordSalt,passwordHash,roleID,cohortID")] DeletedUser deletedUser)
        {
            if (ModelState.IsValid)
            {
                db.DeletedUsers.Add(deletedUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deletedUser);
        }

        // GET: DeletedUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeletedUser deletedUser = db.DeletedUsers.Find(id);
            if (deletedUser == null)
            {
                return HttpNotFound();
            }
            return View(deletedUser);
        }

        // POST: DeletedUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,userID,firstName,lastName,age,gender,email,passwordSalt,passwordHash,roleID,cohortID")] DeletedUser deletedUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deletedUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deletedUser);
        }

        // GET: DeletedUsers/Restore/5
        public ActionResult Restore(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeletedUser deletedUser = db.DeletedUsers.Find(id);
            if (deletedUser == null)
            {
                return HttpNotFound();
            }
            return View(deletedUser);
        }

        // POST: DeletedUsers/Restore/5
        [HttpPost, ActionName("Restore")]
        [ValidateAntiForgeryToken]
        public ActionResult RestoreConfirmed(int id)
        {
            DeletedUser deletedUser = db.DeletedUsers.Find(id);
            db.DeletedUsers.Remove(deletedUser);
            User u = db.Users.Create();
            u.userID = (int)deletedUser.userID;
            u.firstName = deletedUser.firstName;
            u.lastName = deletedUser.lastName;
            u.age = deletedUser.age;
            u.gender = deletedUser.gender;
            u.email = deletedUser.email;
            u.passwordSalt = deletedUser.passwordSalt;
            u.passwordHash = deletedUser.passwordHash;
            u.roleID = (int)deletedUser.roleID;
            u.cohortID = (int)deletedUser.cohortID;
            db.Users.Add(u);
            db.SaveChanges();
            return RedirectToAction("Index","Users");
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
