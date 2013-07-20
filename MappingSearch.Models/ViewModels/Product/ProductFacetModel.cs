using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MappingSearch.Models.ViewModels.Product
{
    public class ProductFacetModel
    {
        public List<string> Subcategories { get; set; }
        public List<string> Brands { get; set; }
    }
}
