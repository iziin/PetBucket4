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