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

        /*Links to Staff_Home page*/
        public ActionResult Staff_Home()
        {
            return View();
        }

        /*Links to Livestream page*/
        public ActionResult Livestream()
        {
            return View();
        }

        /*Links to Pet_Info page*/
        public ActionResult Pet_Info()
        {
            return View();
        }

        /*Links to Your_Pets page*/
        public ActionResult Your_Pets()
        {
            return View();
        }

        /*Links to Account_Details page*/
        public ActionResult Account_Details()
        {
            return View();
        }
    }
}