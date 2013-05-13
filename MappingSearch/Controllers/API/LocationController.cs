using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MappingSearch.Classes;

namespace MappingSearch.Controllers.API
{
    public class LocationController : Controller
    {
        List<Location> _allLocations = new List<Location>{new Location{Details = "NH Details", Id = 1, Lat = 42.0003, Lon = 72.000, Name = "New Hampshire", State = "NH"}, new Location{Details = "Vermont Details", Id=2,Lat = 43.000, Lon = 71.000, Name = "Vermont", State = "VT"}};
        //
        // GET: /Location/
        [HttpGet]
        public JsonResult AllLocations()
        {
            return Json(_allLocations,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddLocation(Location newLocation)
        {
            newLocation = LocationHelper.InitializeLocation(newLocation);
            return Json(newLocation);
        }
    }
}
