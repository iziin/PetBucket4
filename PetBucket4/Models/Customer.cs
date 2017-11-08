using System;
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

        [Required(ErrorMessage = "A first name is required")]
        public string first_name { get; set; }

        public string surname { get; set; }

        [Range(0, 9999999999, ErrorMessage = "Please enter numbers only")]
        public string home_phone { get; set; }

        [Range(0, 9999999999, ErrorMessage = "Please enter numbers only")]
        public string mobile_phone { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Please enter numbers only")]
        public string unit_no { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter numbers only")]
        public string house_no { get; set; }

        [Required(ErrorMessage = "A street name is required")]
        public string street { get; set; }

        [Required(ErrorMessage = "A city/suburb is required")]
        public string city { get; set; }

        [Required(ErrorMessage = "A state is required")]
        public string state { get; set; }

        [Required]
        [Range(1000, 9999, ErrorMessage = "Post Codes must be exactly 4 Numbers")]
        public string postcode { get; set; }

        [Required(ErrorMessage = "An email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string email { get; set; }

        [Required(ErrorMessage = "A password is required")]
        public string password { get; set; }

        public Nullable<System.DateTime> last_logged_in { get; set; }

        public System.DateTime created { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime date_of_birth { get; set; }
    }
}
