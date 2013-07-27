using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MappingSearch.Models;
using MappingSearch.Classes.Product;
using MappingSearch.Models.ViewModels.Product;
using MappingSearch.Models.Product;
using MappingSearch.Constants;

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
            CategoryAndBrandModel model = new CategoryAndBrandModel();
            if (!String.IsNullOrEmpty(id))
            {
                 model = ProductSelectionHelper.GetProductFacets(id);
            }
            return Json(model, JsonRequestBehavior.AllowGet);  
        }

        [HttpPost]
        [Authorize]
        public JsonResult AddGear(NewGearModel model)
        {
            if (!model.ValidOtherBrand())
            {
                ModelState.AddModelError("OtherBrand", "Please enter a new brand");
            }
            if (ModelState.IsValid)
            {

                int id = ProductAddHelper.AddGearProduct(model);

                return Json(String.Format(PathConstants.Pages.ReviewPathWithProductId, "Index", id.ToString()));
            }


            List<string> subcategories = ProductAddHelper.AllSubcategories();
            subcategories.Insert(0, "Select");
            ViewBag.Subcategories = new SelectList(subcategories, model.Subcategory);


            List<string> brands = ProductAddHelper.AllBrands();
            brands.Insert(0, "Select");
            brands.Insert(brands.Count(), "Other..");
            ViewBag.Brands = new SelectList(brands, model.Brand);

            throw new Exception("Errors occured while processing your form");
        }
    }
}
