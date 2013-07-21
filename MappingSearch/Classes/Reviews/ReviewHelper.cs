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

       
        internal static void AddNewReview(ReviewViewModel newReview)
        {
            //Clean inputs 

            Data.Review dbNewReview = new Data.Review();
            dbNewReview.ProductId = newReview.ProductId;
            dbNewReview.LengthOfUse = newReview.LengthOfUse;
            dbNewReview.UserId = newReview.User;
            dbNewReview.StarRating = newReview.Rating;
            dbNewReview.Review1 = newReview.ReviewText;

           Data.Accessors.ReviewsAccessor.AddNewReview(dbNewReview);
        }

        internal static List<ReviewViewModel> GetAllReviewsForPage(int id, int start, int end, string sortMethod)
        {
            List<ReviewViewModel> rawReviews = new List<ReviewViewModel>();
            //validate sortMethod
            
            rawReviews = MappingSearch.Data.Accessors.ReviewsAccessor.GetAllReviewsForPage(id);
            end = rawReviews.Count > end ? end : rawReviews.Count;
            var rawReviewsquery =  rawReviews.Skip(start).Take(end).Select(x => x); 
            if(String.IsNullOrEmpty(sortMethod) || String.Equals("date",sortMethod))
            {
                rawReviews = rawReviewsquery.OrderBy(x => x.PostedDate).Reverse().ToList();
            }

            return rawReviews;
        }

        internal static bool UserHasRevied(int id)
        {
            return MappingSearch.Data.Accessors.ReviewsAccessor.HasUserRevied(id, System.Web.HttpContext.Current.User.Identity.Name);
        }
    }
}