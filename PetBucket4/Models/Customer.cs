﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace PetBucket4.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Customer
    {
        public int id { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string first_name { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string surname { get; set; }

        [Required(ErrorMessage = "Home Phone Number is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter numbers only")]
        public string home_phone { get; set; }

        [Required(ErrorMessage = "Mobile Number is Required")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter numbers only")]
        public string mobile_phone { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Please enter numbers only")]
        public string unit_no { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Please enter numbers only")]
        public string house_no { get; set; }

        public string street { get; set; }

        public string city { get; set; }

        public string state { get; set; }

        [Range(1000, 9999, ErrorMessage = "Post Codes must be no longer then 4 Numbers")]
        public string postcode { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        public string password { get; set; }

        public Nullable<System.DateTime> last_logged_in { get; set; }
        public System.DateTime created { get; set; }
        public Nullable<System.DateTime> date_of_birth { get; set; }
    }
}
