using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MappingSearch.Models.ViewModels.Product
{
    public class ProductViewModel
    {
        private string _image = "/Content/images/unavailable.jpg";
        
        public string ProductImage
        {
            get { return _image; } 
            set 
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _image = value;
                }
            }
        }
        public string Displacement { get; set; }
        public int TopSpeed { get; set; }
        public int Gears { get; set; }
        public int Torque { get; set; }
        public string EngineType { get; set; }

        public string SiteUrl { get; set; }
        public string ProductTitle { get; set; }
        public int ProductId { get; set; }
        public string ProductDescription { get; set; }
        public string ProductBrand { get; set; }
        public string SubmittedBy { get; set; }
        public bool IsApproved { get; set; }
        public bool VisibleToUser { get; set; }
        public bool IsMotorcycle { get; set; }
        public bool IsGear { get; set; }
        public bool IsAccessory { get; set; }
        public string Subcategory { get; set; }
        }
}
