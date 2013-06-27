using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MappingSearch.Models.Account
{
    public class LoginModel
    {
        [Required]
        [Display(Name="User name")]
        public string UserName { get; set; }
        
        [Required]
        [Display(Name="Password")]
        public string Password { get; set; }

        [Display(Name="Remember Me")]
        public bool RememberMe { get; set; }
    }
}