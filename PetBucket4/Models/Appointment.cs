namespace PetBucket4.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Appointment
    {
        public int id { get; set; }
        public Nullable<int> customer_id { get; set; }
        public Nullable<int> pet_id { get; set; }
        public Nullable<System.DateTime> date_start { get; set; }
        public Nullable<System.DateTime> date_end { get; set; }
        public string service { get; set; }
        public Nullable<double> price { get; set; }
        public string needs_pickup { get; set; }
        public string pickup_distance { get; set; }
    }
}
