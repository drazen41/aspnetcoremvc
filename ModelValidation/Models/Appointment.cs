﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModelValidation.Infrastructure;

namespace ModelValidation.Models
{
    public class Appointment
    {
        [Required]
        [Display(Name = "name")]
        public string ClientName { get; set; }
        [UIHint("Date")]
        [Required(ErrorMessage = "Please enter a date")]
        [Remote("ValidateDate","Home")]
        public DateTime Date { get; set; }

        //[Range(typeof(bool), "true", "true", ErrorMessage = "You must accept the terms")]
        [MustBeTrue(ErrorMessage ="You must accept the terms")]
        public bool TermsAccepted { get; set; }
    }
}
