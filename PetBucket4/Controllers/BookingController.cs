using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetBucket4.Models;
using System.Data.Entity.Validation;
using Stripe;

namespace PetBucket4.Controllers
{
    public class BookingController : Controller
    {
        private static String selectedService;
        private static int selectedServiceCharge;

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
                    //BK.pet_id = Convert.ToInt32(Session["petID"].ToString());

                    selectedService = BK.service;

                    db.Appointments.Add(BK);
                    db.SaveChanges();
                    ModelState.Clear();
                    BK = null;
                    return RedirectToAction("Stripe_Payment", "Booking");
                }
            }
            return View();
        }

        public ActionResult Booking_Success(String stripeEmail, String stripeToken)
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
                Amount = selectedServiceCharge,
                Description = "PetBucket " + selectedService,
                Currency = "aud",
                CustomerId = customer.Id
            });
            return View();
        }

        public ActionResult Stripe_Payment()
        {
            var stripePublishKey = ConfigurationManager.AppSettings["stripePublishableKey"];
            ViewBag.StripePublishKey = stripePublishKey;
            if (selectedService.Equals("basic"))
            {
                selectedServiceCharge = 1500;
            }
            else if (selectedService.Equals("standard"))
            {
                selectedServiceCharge = 2500;
            }
            else if (selectedService.Equals("premium"))
            {
                selectedServiceCharge = 3500;
            }
            else
            {
                selectedServiceCharge = 4000;
            }
            ViewBag.ServiceCharge = selectedServiceCharge;
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
            using (PetBucketDatabaseEntities db = new PetBucketDatabaseEntities())
            {
                int userID = Int32.Parse(Session["UserID"].ToString());
                var bookingModel = db.Appointments.Where(u => u.customer_id == userID).ToList();
                
                if (bookingModel != null)
                {
                    return View(bookingModel);
                }
            }
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
        public ActionResult Select_Pet()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Select_Pet(Pet selectedPet)
        {
                using (PetBucketDatabaseEntities db = new PetBucketDatabaseEntities())
                {
                    int userID = Int32.Parse(Session["UserID"].ToString());
                    var pet = db.Pets.Where(m => m.name == selectedPet.name && m.customer_id == userID).FirstOrDefault();
                    if (pet != null)
                    {
                        Session["petID"] = pet.id.ToString();
                        return RedirectToAction("Booking", "Booking");
                    }
                    else
                    {
                        return View();
                    }
                }
        }

        public ActionResult Register_Pet_Success()
        {
            return View();
        }
    }
}
