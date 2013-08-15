using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MappingSearch.Models.Reviews;
using MappingSearch.Classes.Reviews;
using MappingSearch.Models.ViewModels.Reviews;
using MappingSearch.Models.ViewModels.Product;
using MappingSearch.Classes.Product;

namespace MappingSearch.Controllers.Review
{
    public class ReviewController : MasterController
    {
       
        //
        //Get: /ProductReview/
        public ActionResult Index(int? id)
        {
            if(!id.HasValue)
            {
                return View("~/Views/Review/NoParentCategory.cshtml");
            }
            ReviewProductViewModel model = new ReviewProductViewModel();
            model.UserHasReviewed = System.Web.HttpContext.Current.User.Identity.IsAuthenticated ? ReviewHelper.UserHasReviewedProduct(id.Value) : false;
            model.ProductInfo = ProductSelectionHelper.GetProductInfo(id.Value);

            
            return View(model);
        
        }
    }
}
