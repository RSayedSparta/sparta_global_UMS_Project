using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web.Mvc;
using UMS_Project.AuthData;

namespace UMS_Project.Controllers
{
    public class UsersController : Controller
    {
        private User_ManagementDBEntities db = new User_ManagementDBEntities();

        // GET: Users
        [AuthorizationFilter]
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "firstname_desc" : "";
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "lastname_desc" : "";
            ViewBag.NameSortParm = sortOrder == "age" ? "age_desc" : "age";
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "gender_desc" : "";
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "email_desc" : "";
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "cohortName_desc" : "";
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "roleName_desc" : "";
            var users = from u in db.Users
                           select u;
            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(u => u.lastName.Contains(searchString)
                                       || u.firstName.Contains(searchString));                  
            }

            switch (sortOrder)
            {
                case "firstname_desc":
                    users = users.OrderByDescending(u => u.firstName);
                    break;
                case "age":
                    users = users.OrderBy(u => u.age);
                    break;
                case "lastname_desc":
                    users = users.OrderByDescending(u => u.lastName);
                    break;
                case "gender_desc":
                    users = users.OrderByDescending(u => u.gender);
                    break;
                case "email_desc":
                    users = users.OrderByDescending(u => u.email);
                    break;
                case "cohortName_desc":
                    users = users.OrderByDescending(u => u.cohortID);
                    break;
                case "roleName_desc":
                    users = users.OrderByDescending(u => u.roleID);
                    break;
                default:
                    users = users.OrderBy(u => u.firstName);
                    break;
            }
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

                if (ModelState.IsValid)
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Login", "Login");
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
            DeletedUser du = db.DeletedUsers.Create();
            du.userID = user.userID;
            du.firstName = user.firstName;
            du.lastName = user.lastName;
            du.age = user.age;
            du.gender = user.gender;
            du.email = user.email;
            du.passwordSalt = user.passwordSalt;
            du.passwordHash = user.passwordHash;
            du.roleID = user.roleID;
            du.cohortID = user.cohortID;
            db.DeletedUsers.Add(du);
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
