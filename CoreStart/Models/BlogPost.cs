﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreStart.Models
{
    public class BlogPost
    {
        public string Post { get; set; }
        public string Author { get; set; }
        [Required(ErrorMessage = "Please pick a date and a time.")]
        public DateTime? Time { get; set; } //Required attributes must be nullable.

    }
}
