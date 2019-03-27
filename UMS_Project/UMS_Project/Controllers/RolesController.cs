using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UMS_Project;
using PagedList;


namespace UMS_Project.Controllers
{
    public class RolesController : Controller
    {
        private User_ManagementDBEntities db = new User_ManagementDBEntities();

        public object Search_Data { get; private set; }
        public object Filter_Value { get; private set; }
        public int PageNo { get; private set; }

        // GET: Roles
        public ActionResult Index(string SortingOrder, string Search_Data, string Filter_Value, int? PageNo)
        {
            ViewBag.CurrentSort = SortingOrder;
            ViewBag.SortingName = String.IsNullOrEmpty(SortingOrder) ? "Name_Description" : "";
            ViewBag.SortingDescription = String.IsNullOrEmpty(SortingOrder) ? "Description_Description" : "";

            if (Search_Data != null)
            {
                PageNo = 1;
            }
            else
            {
                Search_Data = Filter_Value;
            }

            ViewBag.FilterValue = Search_Data;

            var roles = from role in db.Roles select role;
            switch (SortingOrder)
            {
                case "Name_Description":
                    roles = roles.OrderByDescending(role => role.roleName);
                    break;
                case "Description":
                    roles = roles.OrderBy(role => role.roleDescription);
                    break;
                default:
                    roles = roles.OrderBy(role => role.roleName);
                    break;
            }
            int Size_Of_Page = 10;
            int No_Of_Page = PageNo ?? 1;
            return View(roles.ToPagedList(No_Of_Page, Size_Of_Page));
            //return View(db.Roles.ToList());
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
