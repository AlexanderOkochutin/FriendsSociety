﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPL.ViewModels
{
    public class RegistrationViewModel
    {
        [Display(Name = "Enter your e-mail*")]
        [Required(ErrorMessage = "The field can not be empty")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "incorrect email")]
        [Remote("IsEmailExist","Account",ErrorMessage = "Email whith this name already exist")]
        public string Email { get; set; }

        [Display(Name = "Enter your first name*")]
        [Required(ErrorMessage = "The field can not be empty")]
        public string FirstName { get; set; }
        [Display(Name = "Enter your last name")]
        [Required(ErrorMessage = "The field can not be empty")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Enter your password")]
        [Display(Name = "Password*")]
        [StringLength(100, ErrorMessage = "The password must contain at least {2} characters", MinimumLength = 4)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm the password")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Passwords must match")]
        public string ConfirmPassword { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Enter your birthday date")]
        public DateTime Birthday { get; set; }

        public string DisplayName => LastName + " " + FirstName;
    }
}