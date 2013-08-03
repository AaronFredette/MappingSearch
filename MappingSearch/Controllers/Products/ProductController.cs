using MappingSearch.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MappingSearch.Constants;
using MappingSearch.Classes.Product;
using MappingSearch.Classes;

namespace MappingSearch.Controllers.Products
{
    public class ProductController : MasterController
    {
        #region Gear methods
        //
        // GET: /ProductSelection/

        public ActionResult Category(string id )
        {
            if (!String.IsNullOrEmpty(id) && Constants.HelperClasses.ConstantValidator.IsValidCategory(id))
            {
                ViewBag.CategoryName = id;
                CurrentCategory.SetCurrentCategory(id);
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
            List<string> brands = ProductAddHelper.AllBrands("GEAR");
            brands.Insert(0, "Select");
            ViewBag.Brands = new SelectList(brands);

            List<string> subcategories = ProductAddHelper.AllGearSubcategories();
            subcategories.Insert(0, "Select");
            brands.Insert(brands.Count(), "Other..");
            ViewBag.Subcategories = new SelectList(subcategories);

            return View();
        }

       
        #endregion GEAR 

        #region Motorcycles
        [HttpGet]
        [Authorize]
        public ActionResult AddMotorcycle()
        {
            List<string> brands = ProductAddHelper.AllBrands(Constants.DatabaseConstants.DatabaseConstants.CategoryConstantStrings[Constants.DatabaseConstants.DatabaseConstants.CategoryConstants.MOTORCYCLES]);
            brands.Insert(0, "Select");
            brands.Insert(brands.Count(), "Other..");
            ViewBag.Brands = new SelectList(brands);

            List<string> engineTypes = ProductAddHelper.AllEngineTypes();
            engineTypes.Insert(0, "Select");
            ViewBag.EngineType = new SelectList(engineTypes);

            List<string> subcategories = ProductAddHelper.AllMotorcycleSubcategories();
            subcategories.Insert(0, "Select");
            ViewBag.Subcategories = new SelectList(subcategories);

            return View();
        }

      
        #endregion Motorcycles
    }
}
