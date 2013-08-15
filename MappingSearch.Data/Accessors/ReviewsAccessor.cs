using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MappingSearch.Models.ViewModels.Reviews;
using MappingSearch.Models.ViewModels;

namespace MappingSearch.Data.Accessors
{
    public class ReviewsAccessor
    {
        public static void AddNewReview(Review dbNewReview)
        {
            using (ReviewsDataContext context = new ReviewsDataContext())
            {
                dbNewReview.DatePosted = DateTime.Now;
                context.Reviews.InsertOnSubmit(dbNewReview); //.InsertAllOnSubmit(dbUserModel);
                context.SubmitChanges();
            }
        }

        public static List<ReviewViewModel> GetAllReviewsForPage(int id)
        {
            List<ReviewViewModel> list = new List<ReviewViewModel>();
            using (ReviewsDataContext context = new ReviewsDataContext()) {

                list = (from review in context.Reviews
                            join user in context.Users on review.UserId equals user.UserName
                            join product in context.Products on review.ProductId equals product.ProductId
                            where review.ProductId == id
                            select new ReviewViewModel
                            {
                                User = user.UserName,
                                UserMotorcycle = user.CurrentMotorcycle,
                                Rating = review.StarRating,
                                ReviewText = review.Review1,
                                LengthOfUse = review.LengthOfUse,
                                PostedDateStr = review.DatePosted.ToShortDateString()
                            }).ToList();
                return list;
                 
            }
        }

        public static bool HasUserReviewedProduct(int id, string userId)
        {
            using (ReviewsDataContext context = new ReviewsDataContext())
            {
                var x = (from review in context.Reviews
                        where review.ProductId == id && string.Equals(review.UserId,userId)
                        select review).ToList();

                return x.Count > 0;
            }
        }


        public static bool HasUserReviewedTrack(int id, string userId)
        {
            using (ReviewsDataContext context = new ReviewsDataContext())
            {
                var x = (from review in context.TrackReviews
                         where review.TrackId == id && string.Equals(review.UserId, userId)
                         select review).ToList();

                return x.Count > 0;
            }
        }
        public static List<ReviewViewModel> GetAllTrackReviewsForPage(int id)
        {
            List<ReviewViewModel> list = new List<ReviewViewModel>();
            using (ReviewsDataContext context = new ReviewsDataContext())
            {

                list = (from review in context.TrackReviews
                        join user in context.Users on review.UserId equals user.UserName
                        join track in context.Tracks on review.TrackId equals track.TrackId
                        where review.TrackId == id
                        select new ReviewViewModel
                        {
                            User = user.UserName,
                            UserMotorcycle = user.CurrentMotorcycle,
                            Rating = review.StarRating,
                            ReviewText = review.Review,
                            NumberOfVisits = review.NumberOfVisits.HasValue ? review.NumberOfVisits.Value: 0,
                            PostedDateStr = review.DatePosted.ToShortDateString()
                        }).ToList();
                return list;

            }
        }

        public static void AddNewTrackReview(TrackReview dbNewReview)
        {
            using (ReviewsDataContext context = new ReviewsDataContext())
            {
                dbNewReview.DatePosted = DateTime.Now;
                context.TrackReviews.InsertOnSubmit(dbNewReview); //.InsertAllOnSubmit(dbUserModel);
                context.SubmitChanges();
            }
        }
    }
}
