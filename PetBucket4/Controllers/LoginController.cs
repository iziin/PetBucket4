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
        /* Not currently in use
         
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

    */


        [HttpPost]
        public ActionResult Login(Customer user)
        {
            using (PetBucketDatabaseEntities db = new PetBucketDatabaseEntities())
            {
                var i = db.Customers.Where(u => u.email == user.email && u.password == user.password).FirstOrDefault();
                if (i != null)
                {
                    //Needs something here to update the last logged in time for the account.
                    //i.last_logged_in = DateTime.Now.ToLocalTime();

                    Session["UserID"] = i.id.ToString();
                    Session["Email"] = i.email.ToString();
                    return RedirectToAction("My_Account", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is Incorrect!");
                }
            }
            return View();
        }

        /*Links to Login page*/
        public ActionResult Login()
        {
            return View();
        }

        /*Links to Staff_Login page*/
        public ActionResult Staff_Login()
        {
            return View();
        }

        /*Redirects to Index page when user requests logout*/
        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Customer U)
        {
            if (ModelState.IsValid)
            {
                using (PetBucketDatabaseEntities db = new PetBucketDatabaseEntities())
                {
                    //Adds creation time
                    U.created = DateTime.Now.ToLocalTime();

                    db.Customers.Add(U);
                    db.SaveChanges();
                    ModelState.Clear();
                    U = null;
                    ViewBag.Message = "Successfully Registration Complete";
                }
            }
            return View();
        }

        /*Links to Register page*/
        public ActionResult Register()
        {
            return View();
        }
    }
}