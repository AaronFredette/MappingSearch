using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MappingSearch.Classes.Admin
{
    public class ReviewsAdminHelper
    {
        public static void CalculateAverageReviewsProducts()
        {
            Data.Accessors.ReviewsAccessor.CalculateReviewAverages();
        }
    }
}