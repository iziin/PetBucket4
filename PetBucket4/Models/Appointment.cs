using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

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

        [Required(ErrorMessage = "A starting date is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime start_time { get; set; }

        [Required(ErrorMessage = "An ending date is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime end_time { get; set; }

        public System.DateTime created { get; set; }

        public string food { get; set; }

        public Nullable<int> customer_id { get; set; }

        [Required]
        public string service { get; set; }

        public IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}