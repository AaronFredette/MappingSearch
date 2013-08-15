using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MappingSearch.Models.Account
{
    public class CreateAccountModel
    {
        [Required]
        [MaxLength(50)]
        [Display(Name="User Name")]
        public string UserName { get; set; }

        [Required]
        [RegularExpression(@"^.{5,}$", ErrorMessage = "Minimum 5 characters required")]
        [StringLength(20, ErrorMessage = "Maximum {2} characters exceeded")]
        public string Password { get; set; }

        [Required]
        [Display(Name="Re-type Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name="E-mail Address (This will be used only for password recovery)")]
        [RegularExpression(@"^\w+([-+.]*[\w-]+)*@(\w+([-.]?\w+)){1,}\.\w{2,4}$",ErrorMessage="Invalid E-mail address")]
        public string EmailAddress { get; set; }

        [Display(Name="Current Motorcycle")]
        public string CurrentMotorcycle { get; set; }


        [HiddenInput(DisplayValue=false)]
        public int AdminLevle { get; set; }

    }
}