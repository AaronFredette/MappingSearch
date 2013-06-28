using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MappingSearch.Models.Reviews
{
    public class ProductCategoryBrandModel
    {
        public Dictionary<string,string> Categories { get; set; }
        public Dictionary<string,string> Brands { get; set; }
    }
}