using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MappingSearch.Models;
using MappingSearch.Classes.ProductSelection;
using MappingSearch.Models.ViewModels.Product;

namespace MappingSearch.Controllers.API
{
    public class ProductApiController : Controller
    {
        private const int MAX_RESULTS = 20;

        [HttpGet]
        public JsonResult GetAllProducts(int id,string category,string brand,string subcategory)//id = pageNumber
        {

            List<Data.Product> model = ProductSelectionHelper.GetCategoryBrandModelWithLimit(category,id*MAX_RESULTS, ((id*MAX_RESULTS)+MAX_RESULTS-1), brand,subcategory);

            return Json(model,JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetProductFacets(string id)//id=category
        {
            ProductFacetModel model = new ProductFacetModel();
            if (!String.IsNullOrEmpty(id))
            {
                 model = ProductSelectionHelper.GetProductFacets(id);
            }
            return Json(model, JsonRequestBehavior.AllowGet);  
        }
    }
}
