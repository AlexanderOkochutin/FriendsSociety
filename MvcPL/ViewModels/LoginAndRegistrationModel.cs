using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPL.ViewModels
{
    public class LoginAndRegistrationModel
    {
        public LoginViewModel LoginModel { get; set; }
        public RegistrationViewModel RegistrationModel { get; set; }
    }
}