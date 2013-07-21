using MappingSearch.Models.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MappingSearch.Models.ViewModels.Reviews
{
    public class ReviewProductViewModel
    {
        public bool UserHasReviewed { get; set; }
        public ProductViewModel ProductInfo { get; set; }
    }
}
