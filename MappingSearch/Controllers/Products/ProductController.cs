using MappingSearch.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MappingSearch.Constants;
using MappingSearch.Classes.Product;

namespace MappingSearch.Controllers.Products
{
    public class ProductController : MasterController
    {
        #region Gear methods
        //
        // GET: /ProductSelection/

        public ActionResult Category(string id )
        {
            if (!String.IsNullOrEmpty(id))
            {
                ViewBag.CategoryName = id;
                Data.Motorcycle x = new Data.Motorcycle();
                
                List<Data.Product> model = ProductSelectionHelper.GetCategoryBrandModel(id);
                return View(model);
            }
            return Redirect(MappingSearch.Constants.PathConstants.Pages.ReviewRootPath);
        }

        public ActionResult Index(string id)
        {
            return Redirect("/Reivew/Index");
        }

        
        [HttpGet]
        [Authorize]
        public ActionResult AddGear()
        {
            List<string> brands = ProductAddHelper.AllBrands();
            brands.Insert(0, "Select");
            ViewBag.Brands = new SelectList(brands);

            List<string> subcategories = ProductAddHelper.AllSubcategories();
            subcategories.Insert(0, "Select");
            brands.Insert(brands.Count(), "Other..");
            ViewBag.Subcategories = new SelectList(subcategories);

            return View();
        }

       
        #endregion GEAR 

        #region Motorcycles
        [HttpGet]
        [Authorize]
        public ActionResult AddMotorcycleProduct()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddMotorcycleProduct(NewMotorcycleModel model)
        {
            if (ModelState.IsValid)
            {
                //AddProduct
                //Return category and new product id 
                int id = 1;
                return Redirect(String.Format(PathConstants.Pages.ReviewPathWithProductId, id.ToString()));
            }

            return View(model);
        }
        #endregion Motorcycles
    }
}
