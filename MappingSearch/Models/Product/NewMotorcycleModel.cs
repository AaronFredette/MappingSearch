using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MappingSearch.Models.Product
{
    public class NewMotorcycleModel : NewProductModel
    {
        [Display(Name="Engine displacement")]
        [Required]
        public int Displacement { get; set; }

        [Display(Name="Number of gears")]
        public int Gears {get;set;}

        [Display(Name = "Engine type")]
        public string EngineType { get; set; }

        [Display(Name="Top speed")]
        
        public int TopSpeed { get; set; }
        
        [Display(Name="Torque")]
        public int Torque { get; set; }

    }
}