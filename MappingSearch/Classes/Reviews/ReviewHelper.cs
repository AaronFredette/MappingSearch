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

            Data.Review dbNewReview = CreateDbReview(newReview);

           Data.Accessors.ReviewsAccessor.AddNewReview(dbNewReview);
        }

        internal static void AddNewTrackReview(ReviewViewModel newReview)
        {

            Data.TrackReview dbNewReview = CreateDbTrackReview(newReview);
            Data.Accessors.ReviewsAccessor.AddNewTrackReview(dbNewReview);
        }


        private static Data.TrackReview CreateDbTrackReview(ReviewViewModel newReview)
        {
            Data.TrackReview dbNewReview = new Data.TrackReview();
            dbNewReview.TrackId = newReview.ProductId;
            dbNewReview.NumberOfVisits = newReview.NumberOfVisits;
            dbNewReview.UserId = newReview.User;
            dbNewReview.StarRating = newReview.Rating;
            dbNewReview.Review = newReview.ReviewText;
            return dbNewReview;
        }
        private static Data.Review CreateDbReview(ReviewViewModel newReview)
        {
            Data.Review dbNewReview = new Data.Review();
            dbNewReview.ProductId = newReview.ProductId;
            dbNewReview.LengthOfUse = newReview.LengthOfUse;
            dbNewReview.UserId = newReview.User;
            dbNewReview.StarRating = newReview.Rating;
            dbNewReview.Review1 = newReview.ReviewText;
            return dbNewReview;
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

        internal static bool UserHasReviewed(int id)
        {
            return MappingSearch.Data.Accessors.ReviewsAccessor.HasUserReviewed(id, System.Web.HttpContext.Current.User.Identity.Name);
        }

        internal static List<ReviewViewModel> GetAllTrackReviewsForPage(int id, int start, int end, string sortMethod)
        {
            List<ReviewViewModel> rawReviews = new List<ReviewViewModel>();
            //validate sortMethod
            
            rawReviews = MappingSearch.Data.Accessors.ReviewsAccessor.GetAllTrackReviewsForPage(id);
            end = rawReviews.Count > end ? end : rawReviews.Count;
            var rawReviewsquery =  rawReviews.Skip(start).Take(end).Select(x => x); 
            if(String.IsNullOrEmpty(sortMethod) || String.Equals("date",sortMethod))
            {
                rawReviews = rawReviewsquery.OrderBy(x => x.PostedDate).Reverse().ToList();
            }

            return rawReviews;
        }

        
    }
}