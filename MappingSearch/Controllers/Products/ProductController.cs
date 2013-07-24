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
        //
        // GET: /ProductSelection/

        public ActionResult Category(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                ViewBag.CategoryName = id;
                List<Data.Product> model = ProductSelectionHelper.GetCategoryBrandModel(id);
                return View(model);
            }

            return  Redirect("/Reivew/Index");
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
            brands.Insert(0, String.Empty);
            ViewBag.Brands = new SelectList(brands);
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddGear(NewGearModel model)
        {
            if (ModelState.IsValid)
            {
                int id = ProductAddHelper.AddGearProduct(model);
                return Redirect(String.Format(PathConstants.Pages.ReviewPathWithProductId,"Index", id.ToString()));
            }

            return View(model);
        }


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
    }
}
