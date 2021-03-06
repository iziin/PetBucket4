﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PetBucket4.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Review
    {
        public int id { get; set; }

        public int customer_id { get; set; }

        [Required(ErrorMessage = "Your review is blank!")]
        public string review_text { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "Please choose a rating between 1 and 10")]
        public int rating { get; set; }

        public System.DateTime created { get; set; }
    }
}