using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MappingSearch.Controllers
{
    public class AddLocationController : Controller
    {
        //
        // GET: /AddLocation/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddLocation(NewLocation newLocation)
        {
            //Create Location from new location
            return Json(newLocation);
        }

    }

    public class Location
    {
        public string Name { get; set; }
        public string State { get; set; }
        public string Details { get; set; }
        public double Lat{ get; set; }
        public double Lon { get; set; }
        public int Id { get; set; }
    }

    public class NewLocation
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
    }
}
