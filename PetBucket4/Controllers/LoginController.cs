using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetBucket4.Models;
using System.Data.Entity;

namespace PetBucket4.Controllers
{
    public class LoginController : Controller
    {

        /*Code for login*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Customer user)
        {
            //removes required annotation from model
            ModelState.Remove("first_name");
            ModelState.Remove("house_no");
            ModelState.Remove("street");
            ModelState.Remove("city");
            ModelState.Remove("state");
            ModelState.Remove("postcode");

            if (ModelState.IsValid)
            {
                using (PetBucketDatabaseEntities db = new PetBucketDatabaseEntities())
                {
                    //finds user based on email and password
                    var i = db.Customers.Where(u => u.email == user.email && u.password == user.password).FirstOrDefault();
                    if (i != null)
                    {
                        i.last_logged_in = DateTime.Now.ToLocalTime();
                        db.Entry(i).State = EntityState.Modified;
                        db.SaveChanges();

                        Session["UserID"] = i.id.ToString();
                        Session["Email"] = i.email.ToString();
                        Session["First"] = i.first_name.ToString();
                        ModelState.Clear();
                        return RedirectToAction("My_Account", "User");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Your email or password is incorrect!");
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Your email or password is incorrect!");
            }

            return View();
        }

        /*Links to Login page*/
        public ActionResult Login()
        {
            return View();
        }

        /*Links to Forgot_Password page*/
        public ActionResult Forgot_Password()
        {
            return View();
        }

        //Allows users access to reset their password
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Forgot_Password(Customer form)
        {
            //removes required annotation from model
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
                    //finds user based on email and name
                    var user = db.Customers.Where(u => u.email == form.email && u.first_name == form.first_name).FirstOrDefault();
                    if (user != null)
                    {
                        //creates tempID to be used only for password reset
                        Session["TempUserID"] = user.id;
                        ModelState.Clear();
                        return RedirectToAction("Recover_Password", "Login");
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Your email or name is incorrect!");
            }
            return View();
        }

        /*Links to Forgot_Password page*/
        public ActionResult Recover_Password()
        {
            return View();
        }

        //Allows users to reset their password should they forget it
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Recover_Password(Customer form)
        {
            //removes required annotation from model
            ModelState.Remove("email");
            ModelState.Remove("first_name");
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
                    int userID = Int32.Parse(Session["TempUserID"].ToString());
                    var currentUser = db.Customers.Where(u => u.id == userID).FirstOrDefault();
                    currentUser.password = form.password;

                    db.Entry(currentUser).State = EntityState.Modified;
                    db.SaveChanges();
                    Session["TempUserID"] = null;
                    currentUser = null;
                    ModelState.Clear();
                    return RedirectToAction("Login", "Login");
                }
            }
            return View();
        }


        /*Links to Forgot_Email page*/
        public ActionResult Forgot_Email()
        {
            return View();
        }

        //Allows users to reset their email
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Forgot_Email(Customer form)
        {
            //removes required annotation from model
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
                    //finds user based on name and password
                    var user = db.Customers.Where(u => u.first_name == form.first_name && u.password == form.password).FirstOrDefault();
                    if (user != null)
                    {
                        //creates temp recovery email data
                        Session["RecoveryEmail"] = user.email;
                        return RedirectToAction("Email_Address", "Login");
                    }

                }
            }
            else
            {
                ModelState.AddModelError("", "Your name or password is incorrect!");
            }

            return View();
        }

        /*Links to Forgot_Email page*/
        public ActionResult Email_Address()
        {
            return View();
        }

        /*Redirects to Index page when user requests logout*/
        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        //Creates a new user
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Customer New_User)
        {
            if (ModelState.IsValid)
            {
                using (PetBucketDatabaseEntities db = new PetBucketDatabaseEntities())
                {
                    New_User.created = DateTime.Now.ToLocalTime();

                    db.Customers.Add(New_User);
                    db.SaveChanges();
                    ModelState.Clear();
                    New_User = null;
                    return RedirectToAction("Register_Success", "Login");
                }
            }
            return View();
        }

        /*Links to Register page*/
        public ActionResult Register()
        {
            return View();
        }

        //Links to register_success page
        public ActionResult Register_Success()
        {
            return View();
        }
    }
}