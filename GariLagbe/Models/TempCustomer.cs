﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GariLagbe.Models
{
    public class TempCustomer
    {
        [Required(ErrorMessage = "Please enter your name")]
        [Display(Name = "Full name")]
        [StringLength(20, ErrorMessage = "Your name is too long!")]
        public string Customer_Name { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address!")]
        [Required(ErrorMessage = "Please enter yout email adress")]
        public string Customer_Email { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [MaxLength(20, ErrorMessage = "Password must be within 20 characters")]
        [MinLength(6, ErrorMessage = "Password must contain minimum 6 characters")]
        public string Customer_Password { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        public string Customer_PhoneNO { get; set; }

        [Required(ErrorMessage = "Please enter your address")]
        public string Customer_Address { get; set; }

    }
}