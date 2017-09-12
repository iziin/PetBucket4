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

            return View();
        }

        public ActionResult Booking()
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
            if(ModelState.IsValid)
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

        public ActionResult UserDashBoard()
        {
            return View();
        }

        public ActionResult Gallery()
        {
            return View();
        }

        public ActionResult My_Account()
        {
            return View();
        }
    }
}