using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetBucket4.Models;
using System.Data.Entity.Validation;
using System.Configuration;
using Stripe;

namespace PetBucket4.Controllers
{
    public class BookingController : Controller
    {

        /*Links to Booking page, redirects to Login page if user has not already logged in*/
        public ActionResult Booking()
        {
            return View();
        }

        /*Creates a new appointment in db*/
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
                    return RedirectToAction("Booking_Success", "Booking");
                }
            }
            return View();
        }

        public ActionResult Booking_Success()
        {
            return View();
        }

        /*Links to Register_Pet page*/
        public ActionResult Register_Pet()
        {
            return View();
        }

        /*Creates a new pet in db*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register_Pet(Pet pet)
        {
            if (ModelState.IsValid)
            {
                using (PetBucketDatabaseEntities db = new PetBucketDatabaseEntities())
                {
                    //Adds creation time and customer ID
                    pet.created = DateTime.Now.ToLocalTime();
                    pet.customer_id = Convert.ToInt32(Session["UserID"].ToString());

                    db.Pets.Add(pet);
                    db.SaveChanges();
                    ModelState.Clear();
                    pet = null;
                    return RedirectToAction("Register_Pet_Success", "Booking");
                }
            }
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

        /*Links to Upcoming_Bookings page*/
        public ActionResult Upcoming_Bookings()
        {
            return View();
        }

        /*Links to Select_Pet page*/
        /*Needs to set selected pet to new booking in db*/
        public ActionResult Select_Pet()
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

        public ActionResult Register_Pet_Success()
        {
            return View();
        }

        public ActionResult Stripe_Payment()
        {
            var stripePublishKey = ConfigurationManager.AppSettings["stripePublishableKey"];
            ViewBag.StripePublishKey = stripePublishKey;
            return View();
        }

        public ActionResult Stripe_Charged(string stripeEmail, string stripeToken)
        {
            var customers = new StripeCustomerService();
            var charges = new StripeChargeService();

            var customer = customers.Create(new StripeCustomerCreateOptions
            {
                Email = stripeEmail,
                SourceToken = stripeToken
            });

            var charge = charges.Create(new StripeChargeCreateOptions
            {
                Amount = 500,//charge in cents
                Description = "Sample Charge",
                Currency = "usd",
                CustomerId = customer.Id
            });

            // further application specific code goes here

            return View();
        }
    }
}
