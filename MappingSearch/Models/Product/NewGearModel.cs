using MappingSearch.Classes.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MappingSearch.Models.Product
{
    public class NewGearModel
    {
        [Required]
        [Display(Name="Product Name")]
       public  string ProductName { get; set; }

        [Display(Name="Price")]
        [RegularExpression(@"\d+(\.\d{1,2})?",ErrorMessage="Please enter a valid price. Example 99.00")]
        public string Price { get; set; }

        [Required]
        [Display(Name="Brand")]
        public string Brand { get; set; }

        [Display(Name="Description")]
        public string Description { get; set; }

        [Display(Name = "New Brand")]

        public string OtherBrand { get; set; }
        [Required]
        [Display(Name="Subcategory")]        
        public string Subcategory { get; set; }

        [Display(Name="URL to product site")]
        public string SiteUrl { get; set; }


        public bool ValidOtherBrand()
        {
            if (Brand.Contains("Other"))
            {
                if (String.IsNullOrEmpty(OtherBrand))
                {
                    return false;
                }
                else
                {
                    Brand = OtherBrand;
                    return true;
                }
            }

            return true;
        }
    }
}