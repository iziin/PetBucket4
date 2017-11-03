﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetBucket4.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public partial class Appointment : IEnumerable
    {
        public int id { get; set; }
        public Nullable<int> number_of_pets { get; set; }
        public Nullable<int> pet_id { get; set; }
        public string entry_instructions { get; set; }
        public string care_instructions { get; set; }
        public Nullable<System.DateTime> inspection_visit_date { get; set; }
        public Nullable<System.DateTime> start_time { get; set; }
        public Nullable<System.DateTime> end_time { get; set; }
        public System.DateTime created { get; set; }
        public string food { get; set; }
        public Nullable<int> customer_id { get; set; }
        public string service { get; set; }

        public IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}