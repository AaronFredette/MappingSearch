using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MappingSearch.Models.ViewModels
{
    public class ProductViewModel
    {
        public string ProductImage { get; set; }
        public string ProductTitle { get; set; }
        public int ProductId { get; set; }
        public string ProductDescription { get; set; }
        public string ProductBrand { get; set; }
    }
}
