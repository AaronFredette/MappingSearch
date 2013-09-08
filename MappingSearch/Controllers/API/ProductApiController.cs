﻿using System;
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
        private static int MAX_RESULTS = Constants.ViewConstants.PageCountConstants.MAX_PRODUCTS;

        [HttpGet]
        public JsonResult GetAllProducts(int id,string category,string brand,string subcategory)//id = pageNumber
        {

            var model = ProductSelectionHelper.GetCategoryBrandModelWithLimit(category,id*MAX_RESULTS,  brand,subcategory);

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
        public JsonResult AddGear(NewProductModel model)
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

           
            List<string> subcategories = ProductAddHelper.AllGearSubcategories();
            subcategories.Insert(0, "Select");
            ViewBag.Subcategories = new SelectList(subcategories, model.Subcategory);




            List<string> brands = ProductAddHelper.AllBrands("GEAR");
            brands.Insert(0, "Select");
            brands.Insert(brands.Count(), "Other..");
            ViewBag.Brands = new SelectList(brands, model.Brand);

            Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
            return Json(ModelState.Select(x => x.Value.Errors).ToList());

        }

          [HttpPost]
        [Authorize]
        public ActionResult AddMotorcycle(NewMotorcycleModel model)
        {
            if (!model.ValidOtherBrand())
            {
                ModelState.AddModelError("OtherBrand", "Please enter a new brand");
            }
            if (ModelState.IsValid)
            {

                int id = ProductAddHelper.AddMotorcycleProduct(model);

                return Json(String.Format(PathConstants.Pages.ReviewPathWithProductId, "Index", id.ToString()));
            }

            List<string> engineTypes = ProductAddHelper.AllEngineTypes();
            engineTypes.Insert(0, "Select");
            ViewBag.EngineType = new SelectList(engineTypes, model);

            List<string> subcategories = ProductAddHelper.AllGearSubcategories();
            subcategories.Insert(0, "Select");
            ViewBag.Subcategories = new SelectList(subcategories, model.Subcategory);

            List<string> brands = ProductAddHelper.AllBrands("GEAR");
            brands.Insert(0, "Select");
            brands.Insert(brands.Count(), "Other..");
            ViewBag.Brands = new SelectList(brands, model.Brand);

            throw new Exception("Errors occured while processing your form");
            
            return View(model);
        }
    }
}



           