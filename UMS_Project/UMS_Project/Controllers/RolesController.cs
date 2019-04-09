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
    public class RolesController : Controller
    {
        private User_ManagementDBEntities db = new User_ManagementDBEntities();

        // GET: Roles
        public ActionResult Index(string sort_Order, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sort_Order) ? "roleName_desc" : "";
            ViewBag.NameSortParm = String.IsNullOrEmpty(sort_Order) ? "roleDescription_desc" : "";

            var roles = from r in db.Roles
                        select r;

            if (!String.IsNullOrEmpty(searchString))
            {
                roles = roles.Where(r => r.roleName.Contains(searchString)
                                       || r.roleDescription.Contains(searchString));
            }
            switch (sort_Order)
            {
                case "roleName_desc":
                    roles = roles.OrderByDescending(r => r.roleName);
                    break;
                case "roleDescription_desc":
                    roles = roles.OrderByDescending(r => r.roleDescription);
                    break;
                default:
                    roles = roles.OrderBy(r => r.roleName);
                    break;
            }

            return View(db.Roles.ToList());
        }
        // GET: Roles
        public ActionResult Roles()
        {
            return View();
        }
        

        // GET: Roles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = db.Roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "roleID,roleName,roleDescription")] Role role)
        {
            if (ModelState.IsValid)
            {
                db.Roles.Add(role);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(role);
        }

        // GET: Roles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = db.Roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // POST: Roles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "roleID,roleName,roleDescription")] Role role)
        {
            if (ModelState.IsValid)
            {
                db.Entry(role).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(role);
        }

        // GET: Roles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = db.Roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Role role = db.Roles.Find(id);
            db.Roles.Remove(role);
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
