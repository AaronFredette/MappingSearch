using MappingSearch.Classes.ProductSelection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MappingSearch.Controllers.Products
{
    public class ProductSelectionController : MasterController
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

            return RedirectToAction("~/Reivews/Index");
        }
        


        public ActionResult Index(string id)
        {
            return Redirect("/Reivews/Index");
        }
    }
}
