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

        /*Links to Index page*/
        public ActionResult Index()
        {
            return View();
        }
        
        /*Links to About page*/
        public ActionResult About()
        {

            return View();
        }

        /*Links to Booking page, redirects to Login page if user has not already logged in*/
        public ActionResult Booking()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Booking(Appointment BK)
        {
            if (ModelState.IsValid)
            {
                using (PetBucketDatabaseEntities db = new PetBucketDatabaseEntities())
                {
                    //Adds creation time and customer ID
                    BK.created = DateTime.Now.ToLocalTime();
                    BK.customer_id = Convert.ToInt32(Session["UserID"].ToString());

                    db.Appointments.Add(BK);
                    db.SaveChanges();
                    ModelState.Clear();
                    BK = null;
                    ViewBag.Message = "Booking completed";
                }
            }
            return View();
        }

        /*Links to Reviews page*/
        public ActionResult Reviews()
        {
            return View();
        }

        /*Links to Community page*/
        public ActionResult Community()
        {
            return View();
        }

        /*Links to Services page*/
        public ActionResult Services()
        {
            return View();
        }

        /*Links to Gallery page*/
        public ActionResult Gallery()
        {
            return View();
        }

        /*Links to Manage_Bookings page*/
        public ActionResult Manage_Bookings()
        {
            return View();
        }

        /*Links to Current_Bookings page*/
        public ActionResult Current_Bookings()
        {
            return View();
        }

        /*Redirects to Facebook page*/
        public ActionResult Facebook()
        {
            return Redirect("https://www.facebook.com/peter.bucket.545");
        }

        /*Redirects to Instagram page*/
        public ActionResult Instagram()
        {
            return Redirect("https://www.instagram.com/pet.bucket/");
        }

        /*Redirects to Twitter page*/
        public ActionResult Twitter()
        {
            return Redirect("https://twitter.com/petbucket4");
        }
    }
}