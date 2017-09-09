using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetBucket4.Models;

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
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Booking()
        {
            ViewBag.Message = "Booking Page.";

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
        public ActionResult Register(Customer X)
        {
            if(ModelState.IsValid)
            {
                using (PetBucketDatabaseEntities db = new PetBucketDatabaseEntities())
                {
                    db.Customers.Add(X);
                    db.SaveChanges();
                    ModelState.Clear();
<<<<<<< HEAD
                    X = null;
                    ViewBag.Message = "Successfully Registration Complete";
=======
                    U = null;
                    ViewBag.Message = "Registration Complete";
>>>>>>> origin/master
                }
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Booking(Pet U)
        {
            if (ModelState.IsValid)
            {
                using (PetBucketDatabaseEntities db = new PetBucketDatabaseEntities())
                {
                    db.Pets.Add(U);
                    db.SaveChanges();
                    ModelState.Clear();
                    U = null;
                    ViewBag.Message = "Successfully Booking Completed";
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

        public ActionResult UserDashBoard()
        {
            return View();
        }

        public ActionResult MyAccount()
        {
            return View();
        }
    }
}