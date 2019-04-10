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
    public class LoginController : Controller
    {
        private User_ManagementDBEntities db = new User_ManagementDBEntities();

        //GET: Login
        public ActionResult Login()
        {
            Session["Role"] = 0;
            return View();
        }
        //POST: Login
        [HttpPost]
        public ActionResult Login(User user)
        {
            User usr = db.Users.SingleOrDefault(u => u.email.Equals(user.email));
            if (usr == null)
            {
                return RedirectToAction("Create", "Users");
            }
            else
            {

                string salt = usr.passwordSalt;

                string hash = PasswordSecurity.GenerateHash(user.password, salt);
                user.passwordHash = hash;

                if (usr.passwordHash != hash)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    //Admin directed to user list table
                    Session["Email"] = usr.email;
                    Session["Name"] = usr.firstName;
                    Session["Role"] = usr.roleID;
                    Session["ID"] = usr.userID;
                    Session.Timeout = 4;
                    if (Session["Role"].ToString() == "1")
                    {
                        return RedirectToAction("Index", "Users");
                    }
                    else
                    {
                        //user directed to own details 
                        return View("Details", usr);
                    }
                }

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

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Home");

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
