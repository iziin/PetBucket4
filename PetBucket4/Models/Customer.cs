namespace PetBucket4.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Customer
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string given_name { get; set; }
        public string surname { get; set; }
        public string address { get; set; }
        public Nullable<System.DateTime> last_logged_in { get; set; }
        public string mobile_no { get; set; }
    }
}
