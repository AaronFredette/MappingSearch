using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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

        [Required]
        [Display(Name="Sub Category")]
        public string SubCategory { get; set; }

        [Display(Name="URL to product site")]
        public string SiteUrl { get; set; }
    }
}