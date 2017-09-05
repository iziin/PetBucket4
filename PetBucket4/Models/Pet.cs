using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetBucket4.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Animal { get; set; }
        public string Size { get; set; }
        public string Food { get; set; }
        public string Photo { get; set; }
        public int CustomerId { get; set; }




    }
}