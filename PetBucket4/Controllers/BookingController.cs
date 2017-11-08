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
        private static int day_diff;
        private int validStart;

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
                    //finds differnece between start and end dates
                    //finds difference between start date and current date
                    day_diff = BK.end_time.DayOfYear - BK.start_time.DayOfYear;
                    validStart = BK.start_time.DayOfYear - DateTime.Today.DayOfYear;

                    //if there is more than one day between start and end date
                    if (day_diff > 0)
                    {
                        //if the start date is at least on day more than the current date
                        if(validStart > 0)
                        {
                            BK.created = DateTime.Now.ToLocalTime();
                            BK.customer_id = Convert.ToInt32(Session["UserID"].ToString());
                            BK.pet_id = Convert.ToInt32(Session["petID"].ToString());
                            BK.number_of_pets = 1;
                            selectedService = BK.service;

                            db.Appointments.Add(BK);
                            db.SaveChanges();
                            ModelState.Clear();
                            BK = null;
                            return RedirectToAction("Stripe_Payment", "Booking");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Please enter a valid start date.");
                        }

                    }
                    else
                    {
                        ModelState.AddModelError("", "Please enter valid dates.");
                    }
                }
            }
            return View();
        }

        /*Links to Booking page, redirects to Login page if user has not already logged in*/
        public ActionResult Booking_TYD()
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

        /*Creates a new To your door appointment in db*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Booking_TYD(Appointment BK)
        {
            if (ModelState.IsValid)
            {
                using (PetBucketDatabaseEntities db = new PetBucketDatabaseEntities())
                {
                    //finds differnece between start and end dates
                    //finds difference between start date and current date
                    day_diff = BK.end_time.DayOfYear - BK.start_time.DayOfYear;
                    validStart = BK.start_time.DayOfYear - DateTime.Today.DayOfYear;

                    //if there is more than one day between start and end date
                    if (day_diff > 0)
                    {
                        //if the start date is at least on day more than the current date
                        if (validStart > 0)
                        {
                            //if there is a date selected for inspection
                            if (BK.inspection_visit_date != null)
                            {
                                //if inspection date is before the start date but after the current date
                                if (BK.inspection_visit_date < BK.start_time && BK.inspection_visit_date > DateTime.Now.ToLocalTime())
                                {
                                    //if there is anything in the entry instructions textbox
                                    if (BK.entry_instructions != null)
                                    {
                                        BK.created = DateTime.Now.ToLocalTime();
                                        BK.customer_id = Convert.ToInt32(Session["UserID"].ToString());
                                        selectedService = BK.service;

                                        db.Appointments.Add(BK);
                                        db.SaveChanges();
                                        ModelState.Clear();
                                        BK = null;
                                        return RedirectToAction("Stripe_Payment", "Booking");
                                    }
                                    if (BK.entry_instructions == null)
                                    {
                                        ModelState.AddModelError("", "Please enter some brief entry instructions to your property.");
                                    }
                                }
                                if (BK.inspection_visit_date >= BK.start_time)
                                {
                                    ModelState.AddModelError("", "Please enter an inpsection date that is before the starting date of your booking.");
                                }
                                if (BK.inspection_visit_date <= DateTime.Now.ToLocalTime())
                                {
                                    ModelState.AddModelError("", "Please enter a valid inspection date.");
                                }
                            }
                            if (BK.inspection_visit_date == null)
                            {
                                ModelState.AddModelError("", "Please enter an inspection date.");
                            }    
                        }
                        else
                        {
                            ModelState.AddModelError("", "Please enter a valid start date.");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Please enter valid dates.");
                    }
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
            //calculates charge 
            if (selectedService.Equals("basic"))
            {
                selectedServiceCharge = 1500 * day_diff;
            }
            //calculates charge 
            else if (selectedService.Equals("standard"))
            {
                selectedServiceCharge = 2000 * day_diff;
            }
            //calculates charge 
            else if (selectedService.Equals("premium"))
            {
                selectedServiceCharge = 2800 * day_diff;
            }
            //calculates charge 
            else
            {
                selectedServiceCharge = 5000 * day_diff;
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
                //finds users appointments based on userID
                int userID = Int32.Parse(Session["UserID"].ToString());
                var bookingModel = db.Appointments.Where(u => u.customer_id == userID).ToList();
                
                if (bookingModel != null)
                {
                    return View(bookingModel);
                }
            }
            return View();
        }

        /*Links to Select_Pet page*/
        public ActionResult Select_Pet()
        {
            return View();
        }

        //Selects a pet for a new booking
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Select_Pet(Pet selectedPet)
        {
            if (ModelState.IsValid)
            {
                using (PetBucketDatabaseEntities db = new PetBucketDatabaseEntities())
                {
                    //finds pets based on userID and name
                    int userID = Int32.Parse(Session["UserID"].ToString());
                    var pet = db.Pets.Where(m => m.name == selectedPet.name && m.customer_id == userID).FirstOrDefault();
                    if (pet != null)
                    {
                        Session["petID"] = pet.id.ToString();
                        return RedirectToAction("Booking", "Booking");
                    }
                }
            }
            ModelState.AddModelError("", "You Must Select A Pet You Have Registered");
            return View();
        }

        //links to Register_Pet_Success page
        public ActionResult Register_Pet_Success()
        {
            return View();
        }
    }
}
