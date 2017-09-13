namespace PetBucket4.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pet
    {
        public int id { get; set; }
        public string name { get; set; }
        public string animal { get; set; }
        public string size { get; set; }
        public string food { get; set; }
        public string photo { get; set; }
        public int customer_id { get; set; }
        public string active { get; set; }
        public string indoors_safe { get; set; }
        public string under13_safe { get; set; }
    }
}
