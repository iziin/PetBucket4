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

        //creates new db context for home controller
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

        /*Redirects to Facebook page*/
        public ActionResult Facebook()
        {
            return Redirect("https://www.facebook.com/PetBucket-1210864389059345/");
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

        //links to new_review page if user is logged in
        public ActionResult New_Review()
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

        //submits review to db
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult New_Review([Bind(Include = "review_text,rating")] Review _review)
        {

            if(ModelState.IsValid)
            {
                _review.customer_id = Convert.ToInt32(Session["UserID"].ToString());
                _review.created = DateTime.Now;
                _db.Reviews.Add(_review);
                _db.SaveChanges();

                ModelState.Clear();
                _review = null;
                return RedirectToAction("Reviews", "Home");
            }
            return View(_review);
        }

        //links to reviews page and displays reviews
        public ActionResult Reviews()
        {
            using (PetBucketDatabaseEntities db = new PetBucketDatabaseEntities())
            {
                var model = db.Reviews.ToList();
                if (model != null)
                {
                    return View(model);
                }
            }
            return View();
        }

    }
}