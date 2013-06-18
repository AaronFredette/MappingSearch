using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MappingSearch.Classes;
using MappingSearch.Models;

namespace MappingSearch.Controllers.API
{
    public class LocationController : Controller
    {
        
        //
        // GET: /Location/
        [HttpGet]
        public JsonResult AllLocations()
        {
            return Json(MappingSearch.Data.Locations.GetAllLocations(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult SearchStateLocations(string id)
        {
            return Json(MappingSearch.Data.Locations.SearchStateLocations(id), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult SearchDistance(string zip, int distance) 
        {
            List<Location> qualifiedLocations = LocationHelper.FindLocationsInDistance(zip, distance);
            return Json(qualifiedLocations, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddLocation(Location newLocation)
        {
            newLocation = LocationHelper.InitializeLocation(newLocation);
            return Json(newLocation);
        }
    }
}
