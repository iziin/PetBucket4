namespace PetBucket4.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Customer
    {
        public int id { get; set; }
        [Required(ErrorMessage ="Please provide username", AllowEmptyStrings =false)]
        public string username { get; set; }
        [Required(ErrorMessage = "Please provide password", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        [StringLength(50,MinimumLength =8, ErrorMessage ="Password must be 8 characters long!")]
        public string password { get; set; }
        public string email { get; set; }
        public string given_name { get; set; }
        public string surname { get; set; }
        public string address { get; set; }
        public Nullable<System.DateTime> last_logged_in { get; set; }
        public string mobile_no { get; set; }
    }
}
