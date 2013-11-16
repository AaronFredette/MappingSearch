using System;   
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MappingSearch.Constants;
using MappingSearch.Models.ViewModels.Reviews;
using MappingSearch.Models.ViewModels;

namespace MappingSearch.Classes.Reviews
{
    public class ReviewHelper
    {
        private static int MAX_REVIEWS = Constants.ViewConstants.PageCountConstants.MAX_REVIEWS;
       
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
            dbNewReview.Review = FormInputHelper.StripInput(newReview.ReviewText);
            return dbNewReview;
        }
        private static Data.Review CreateDbReview(ReviewViewModel newReview)
        {
            Data.Review dbNewReview = new Data.Review();
            dbNewReview.ProductId = newReview.ProductId;
            dbNewReview.LengthOfUse = newReview.LengthOfUse;
            dbNewReview.UserId = newReview.User;
            dbNewReview.StarRating = newReview.Rating;
            dbNewReview.Review1 = FormInputHelper.StripInput(newReview.ReviewText);
            return dbNewReview;
        }

        internal static ResponseModel<List<ReviewViewModel>> GetAllReviewsForPage(int id, int start, int end, string sortMethod)
        {
            ResponseModel<List<ReviewViewModel>>  response = new ResponseModel<List<ReviewViewModel>>();
            List<ReviewViewModel> rawReviews = new List<ReviewViewModel>();
            //validate sortMethod
            
            rawReviews = MappingSearch.Data.Accessors.ReviewsAccessor.GetAllReviewsForPage(id);
            response.PageCount = (rawReviews.Count() + MAX_REVIEWS-1 )/ MAX_REVIEWS;
            end = rawReviews.Count > end ? end : rawReviews.Count;
            var rawReviewsquery =  rawReviews.Skip(start).Take(end).Select(x => x); 
            if(String.IsNullOrEmpty(sortMethod) || String.Equals("date",sortMethod))
            {
                rawReviews = rawReviewsquery.OrderBy(x => x.PostedDate).Reverse().ToList();
            }

            response.Model = rawReviews;
            
            return response;
        }

        internal static bool UserHasReviewedProduct(int id)
        {
            
            return MappingSearch.Data.Accessors.ReviewsAccessor.HasUserReviewedProduct(id, System.Web.HttpContext.Current.User.Identity.Name);
        }

        internal static bool UserHasReviewedTrack(int id)
        {
                return MappingSearch.Data.Accessors.ReviewsAccessor.HasUserReviewedTrack(id, System.Web.HttpContext.Current.User.Identity.Name);
           }
        internal static ResponseModel<List<ReviewViewModel>> GetAllTrackReviewsForPage(int id, int start, int end, string sortMethod)
        {
            ResponseModel<List<ReviewViewModel>> response = new ResponseModel<List<ReviewViewModel>>();
            List<ReviewViewModel> rawReviews = new List<ReviewViewModel>();
            //validate sortMethod
            
            rawReviews = MappingSearch.Data.Accessors.ReviewsAccessor.GetAllTrackReviewsForPage(id);
            end = rawReviews.Count > end ? end : rawReviews.Count;
            var rawReviewsquery =  rawReviews.Skip(start).Take(end).Select(x => x); 
            if(String.IsNullOrEmpty(sortMethod) || String.Equals("date",sortMethod))
            {
                rawReviews = rawReviewsquery.OrderBy(x => x.PostedDate).Reverse().ToList();
            }
            response.Model = rawReviews;
            return response;
        }

        
    }
}