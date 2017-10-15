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

namespace PetBucket4.Controllers
{
    public class BookingController : Controller
    {
        /*
        //OLD CONTROLLER SECTION, NOT IN USE

        private PetBucketDatabaseEntities db = new PetBucketDatabaseEntities();

        // GET: Booking
        public ActionResult Index()
        {
            return View(db.Pets.ToList());
        }

        // GET: Booking/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = db.Pets.Find(id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            return View(pet);
        }

        // GET: Booking/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Booking/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,animal,size,food,photo,customer_id,active,indoors_safe,under13_safe")] Pet pet)
        {
            if (ModelState.IsValid)
            {
                db.Pets.Add(pet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pet);
        }

        // GET: Booking/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = db.Pets.Find(id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            return View(pet);
        }

        // POST: Booking/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,animal,size,food,photo,customer_id,active,indoors_safe,under13_safe")] Pet pet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pet);
        }

        // GET: Booking/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = db.Pets.Find(id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            return View(pet);
        }

        // POST: Booking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pet pet = db.Pets.Find(id);
            db.Pets.Remove(pet);
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


        */










        
        //CURRENT CONTROLER SECTION
        
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

                    db.Appointments.Add(BK);
                    db.SaveChanges();
                    ModelState.Clear();
                    BK = null;
                    ViewBag.Message = "Booking completed";
                }
            }
            return View();
        }

        /*Links to Register_Pet page*/
        public ActionResult Register_Pet()
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
                    ViewBag.Message = "Pet Registered";
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
    }
}
