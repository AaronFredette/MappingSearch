using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MappingSearch.Models.Reviews;

namespace MappingSearch.Controllers.Reviews
{
    public class ReviewsController : Controller
    {
       
        //
        //Get: /ProductReview/
        public ActionResult Index()
        {
            return View("NoParentCategory",new ProductCategoryBrandModel());
        
        }

        public ActionResult Category(string id)
        {
            ViewBag.CategoryName = id;
            return View();
        }
    }
}
