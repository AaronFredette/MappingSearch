using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MappingSearch.Models.ViewModels.Reviews
{
    public class ProductReviewViewModel
    {
        public ProductViewModel ProductData { get; set; }
        public List<ReviewViewModel> Reveiws {get;set;}
        
    }
}
