using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetBucket4.Models;
using System.Data.Entity;

namespace PetBucket4.Controllers
{
    public class HomeController : Controller
    {
        //Database
        PetBucketDatabaseEntities _db;

        public HomeController()
        {
            _db = new PetBucketDatabaseEntities();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Booking()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Booking(Appointment BK)
        {
            if (ModelState.IsValid)
            {
                using (PetBucketDatabaseEntities db = new PetBucketDatabaseEntities())
                {
                    db.Appointments.Add(BK);
                    db.SaveChanges();
                    ModelState.Clear();
                    BK = null;
                    ViewBag.Message = "Successfully Registration Complete";
                }
            }
            return View();
        }

        public ActionResult Reviews()
        {
            return View();
        }

        public ActionResult Community()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Customer U)
        {
            if (ModelState.IsValid)
            {
                using (PetBucketDatabaseEntities db = new PetBucketDatabaseEntities())
                {
                    db.Customers.Add(U);
                    db.SaveChanges();
                    ModelState.Clear();
                    U = null;
                    ViewBag.Message = "Successfully Registration Complete";
                }
            }
            return View();
        }

        public ActionResult Services()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Customer user)
        {
            using (PetBucketDatabaseEntities db = new PetBucketDatabaseEntities())
            {
                var i = db.Customers.Where(u => u.username == user.username && u.password == user.password).FirstOrDefault();
                if (i != null)
                {
                    Session["UserID"] = i.id.ToString();
                    Session["Username"] = i.username.ToString();
                    return RedirectToAction("My_Account");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is Incorrect!");
                }
            }
            return View();
        }

        public ActionResult My_Account()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }

        public ActionResult Gallery()
        {
            return View();
        }

        public ActionResult Manage_Bookings()
        {
            return View();
        }

        public ActionResult Staff()
        {
            return View();
        }

        public ActionResult Current_Bookings()
        {
            return View();
        }

        public ActionResult Facebook()
        {
            return Redirect("https://www.facebook.com/peter.bucket.545");
        }

        public ActionResult Instagram()
        {
            return Redirect("https://www.instagram.com/pet.bucket/");
        }

        public ActionResult Twitter()
        {
            return Redirect("https://twitter.com/petbucket4");
        }

        public ActionResult Your_Pets()
        {
            return View();
        }

        public ActionResult Pet_Info()
        {
            return View();
        }

        public ActionResult Livestream()
        {
            return View();
        }

        public ActionResult Staff_Login()
        {
            return View();
        }
    }
}