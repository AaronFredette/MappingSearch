using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MappingSearch.Models.Reviews;
using MappingSearch.Classes.Reviews;
using MappingSearch.Models.ViewModels.Reviews;

namespace MappingSearch.Controllers.API
{
    public class ReviewApiController : MasterController
    {
        private const int MAX_REVIEWS = 10;
        [HttpPost]
        [Authorize]
        public void AddReview(ReviewViewModel newReview)
        {
            newReview.User = System.Web.HttpContext.Current.User.Identity.Name;
             ReviewHelper.AddNewReview(newReview);
            //return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetAllReviewsForPage(int id,int pageNumber, string sortMethod) { //id == productID
            
            List<ReviewViewModel> model = ReviewHelper.GetAllReviewsForPage(id, pageNumber * MAX_REVIEWS, ((pageNumber * MAX_REVIEWS) + MAX_REVIEWS - 1), sortMethod);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetAllTrackReviewsForPage(int id, int pageNumber, string sortMethod) 
        {
            List<ReviewViewModel> model = ReviewHelper.GetAllTrackReviewsForPage(id, pageNumber * MAX_REVIEWS, ((pageNumber * MAX_REVIEWS) + MAX_REVIEWS - 1), sortMethod);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [Authorize]
        public void AddTrackReview(ReviewViewModel newReview)
        {
            newReview.User = System.Web.HttpContext.Current.User.Identity.Name;
            ReviewHelper.AddNewTrackReview(newReview);
        }
        
    }
}
