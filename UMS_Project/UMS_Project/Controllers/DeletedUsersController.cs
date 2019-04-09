using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UMS_Project;
using UMS_Project.AuthData;

namespace UMS_Project.Controllers
{
    [AuthorizationFilter]
    public class DeletedUsersController : Controller
    {
        private User_ManagementDBEntities db = new User_ManagementDBEntities();

        // GET: DeletedUsers
        public ActionResult Index()
        {
            return View(db.DeletedUsers.ToList());
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
            u.password = "Empty123";
            //u.confirmPassword = "Empty123";
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
