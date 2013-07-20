using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MappingSearch.Models.Reviews;
using MappingSearch.Classes.Reviews;
using MappingSearch.Models.ViewModels.Reviews;

namespace MappingSearch.Controllers.Review
{
    public class ReviewController : MasterController
    {
       
        //
        //Get: /ProductReview/
        public ActionResult Index(int id)
        {
            if(id == null)
            {
                return View("~/Views/Review/NoParentCategory.cshtml");
            }
            ProductReviewViewModel model = ReviewHelper.GetReviewsForProduct(id);
            return View(model);
        
        }
    }
}
