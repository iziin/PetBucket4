using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetBucket4.Models;
using System.Data.Entity;

namespace PetBucket4.Controllers
{
    public class UserController : Controller
    {

        /*Links to My_Account page if user has logged in, otherwise, redirects to Login page*/
        public ActionResult My_Account()
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

        /*Links to Livestream page*/
        public ActionResult Livestream()
        {
            return View();
        }

        /*Links to Your_Pets page*/
        public ActionResult Your_Pets()
        {
            using (PetBucketDatabaseEntities db = new PetBucketDatabaseEntities())
            {
                //finds user's pets based on userID
                int userID = Int32.Parse(Session["UserID"].ToString());
                var model = db.Pets.Where(u => u.customer_id == userID).ToList();
                if (model != null)
                {
                    return View(model);
                }
            }
            return View();
        }

        /*Links to Account_Details page*/
        public ActionResult Account_Details()
        {
            using (PetBucketDatabaseEntities db = new PetBucketDatabaseEntities())
            {
                int userID = Int32.Parse(Session["UserID"].ToString());
                var accDets = db.Customers.Where(u => u.id == userID).FirstOrDefault();
                if (accDets != null)
                {
                    return View(accDets);
                }
            }
            return View();
        }

        /*Links to Edit_Address page*/
        public ActionResult Edit_Address()
        {
            return View();
        }

        //Allows users change their address
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit_Address(Customer user)
        {
            //removes annotations from model
            ModelState.Remove("first_name");
            ModelState.Remove("email");
            ModelState.Remove("password");

            if (ModelState.IsValid)
            {
                using (PetBucketDatabaseEntities db = new PetBucketDatabaseEntities())
                {
                    //finds user based on UserID
                    int userID = Int32.Parse(Session["UserID"].ToString());
                    var currentUser = db.Customers.Where(u => u.id == userID).FirstOrDefault();
                    currentUser.unit_no = user.unit_no;
                    currentUser.house_no = user.house_no;
                    currentUser.street = user.street;
                    currentUser.city = user.city;
                    currentUser.state = user.state;
                    currentUser.postcode = user.postcode;

                    db.Entry(currentUser).State = EntityState.Modified;
                    db.SaveChanges();
                    ModelState.Clear();
                    user = null;
                    return RedirectToAction("Account_Details", "User");
                }
            }
            return View();
        }

        /*Links to Edit_Email page*/
        public ActionResult Edit_Email()
        {
            return View();
        }

        //Allows users to edit their email
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit_Email(Customer user)
        {
            //removes annotations from model
            ModelState.Remove("first_name");
            ModelState.Remove("password");
            ModelState.Remove("house_no");
            ModelState.Remove("street");
            ModelState.Remove("city");
            ModelState.Remove("state");
            ModelState.Remove("postcode");

            if (ModelState.IsValid)
            {
                using (PetBucketDatabaseEntities db = new PetBucketDatabaseEntities())
                {
                    //finds user based on ID
                    int userID = Int32.Parse(Session["UserID"].ToString());
                    var currentUser = db.Customers.Where(u => u.id == userID).FirstOrDefault();
                    currentUser.email = user.email;

                    db.Entry(currentUser).State = EntityState.Modified;
                    db.SaveChanges();
                    ModelState.Clear();
                    user = null;
                    return RedirectToAction("Account_Details", "User");
                }
            }
            return View();
        }

        /*Links to Edit_HomeP page*/
        public ActionResult Edit_HomeP()
        {
                return View();
        }

        //allows users to edit their home phone number
       [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Edit_HomeP(Customer user)
        {
            //removes annotations from model
            ModelState.Remove("first_name");
            ModelState.Remove("email");
            ModelState.Remove("password");
            ModelState.Remove("house_no");
            ModelState.Remove("street");
            ModelState.Remove("city");
            ModelState.Remove("state");
            ModelState.Remove("postcode");

            if (ModelState.IsValid)
            {
                using (PetBucketDatabaseEntities db = new PetBucketDatabaseEntities())
                {
                    //finds user based on ID
                    int userID = Int32.Parse(Session["UserID"].ToString());
                    var currentUser = db.Customers.Where(u => u.id == userID).FirstOrDefault();
                    currentUser.home_phone = user.home_phone;

                    db.Entry(currentUser).State = EntityState.Modified;
                    db.SaveChanges();
                    ModelState.Clear();
                    user = null;
                    return RedirectToAction("Account_Details", "User");
                }
            }
            return View();
        }

        /*Links to Edit_HomeP page*/
        public ActionResult Edit_Mobile()
        {
            return View();
        }

        //Allows users to edit mobile phone number
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit_Mobile(Customer user)
        {
            //removes annotations from model
            ModelState.Remove("first_name");
            ModelState.Remove("email");
            ModelState.Remove("password");
            ModelState.Remove("house_no");
            ModelState.Remove("street");
            ModelState.Remove("city");
            ModelState.Remove("state");
            ModelState.Remove("postcode");

            if (ModelState.IsValid)
            {
                using (PetBucketDatabaseEntities db = new PetBucketDatabaseEntities())
                {
                    //finds user based on ID
                    int userID = Int32.Parse(Session["UserID"].ToString());
                    var currentUser = db.Customers.Where(u => u.id == userID).FirstOrDefault();
                    currentUser.mobile_phone = user.mobile_phone;

                    db.Entry(currentUser).State = EntityState.Modified;
                    db.SaveChanges();
                    ModelState.Clear();
                    user = null;
                    return RedirectToAction("Account_Details", "User");
                }
            }
            return View();
        }

        /*Links to Change_Password page*/
        public ActionResult Change_Password()
        {
            return View();
        }

        /*Asks user to enter thier current password for verification*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Change_Password(Customer user)
        {
            //removes annotations from model
            ModelState.Remove("first_name");
            ModelState.Remove("email");
            ModelState.Remove("house_no");
            ModelState.Remove("street");
            ModelState.Remove("city");
            ModelState.Remove("state");
            ModelState.Remove("postcode");

            if (ModelState.IsValid)
            {
                using (PetBucketDatabaseEntities db = new PetBucketDatabaseEntities())
                {
                    //finds user based on ID
                    int userID = Int32.Parse(Session["UserID"].ToString());
                    var currentUser = db.Customers.Where(u => u.id == userID).FirstOrDefault();
                    if (currentUser.password == user.password)
                    {
                        user = null;
                        return RedirectToAction("New_Password", "User");
                    }
                    ModelState.AddModelError("", "Your Password is Incorrect!");
                }
            }
            return View();
        }

        /*Links to New_Password page*/
        public ActionResult New_Password()
        {
            return View();
        }


        /*Allows users to change their password*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult New_Password(Customer user)
        {
            //removes annotations from model
            ModelState.Remove("first_name");
            ModelState.Remove("email");
            ModelState.Remove("house_no");
            ModelState.Remove("street");
            ModelState.Remove("city");
            ModelState.Remove("state");
            ModelState.Remove("postcode");

            if (ModelState.IsValid)
            {
                using (PetBucketDatabaseEntities db = new PetBucketDatabaseEntities())
                {
                    //finds user based on ID
                    int userID = Int32.Parse(Session["UserID"].ToString());
                    var currentUser = db.Customers.Where(u => u.id == userID).FirstOrDefault();
                    currentUser.password = user.password;

                    db.Entry(currentUser).State = EntityState.Modified;
                    db.SaveChanges();
                    ModelState.Clear();
                    user = null;
                    return RedirectToAction("Change_Password_Success", "User");
                }
            }
            return View();
        }

        //links to change_password_success page
        public ActionResult Change_Password_Success()
        {
            return View();
        }
    }
}