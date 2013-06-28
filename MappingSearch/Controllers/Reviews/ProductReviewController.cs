using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MappingSearch.Models.Reviews;

namespace MappingSearch.Controllers.Reviews
{
    public class ProductReviewController : Controller
    {
        //
        // GET: /ProductReview/

        public ActionResult Index()
        {

            return View(new ProductCategoryBrandModel());
        }

    }
}
