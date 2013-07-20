using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MappingSearch.Constants;
using MappingSearch.Models.ViewModels.Reviews;

namespace MappingSearch.Classes.Reviews
{
    public class ReviewHelper
    {

        internal static ProductReviewViewModel GetReviewsForProduct(int id)
        {
          return Data.Accessors.ReviewsAccessor.GetAllReviewsForProdcut(id);
        }
    }
}