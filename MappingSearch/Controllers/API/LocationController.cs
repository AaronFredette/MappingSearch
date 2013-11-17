using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MappingSearch.Classes.Track;
using MappingSearch.Models;
using MappingSearch.Models.Tracks;
using MappingSearch.Models.ViewModels.Tracks;

namespace MappingSearch.Controllers.API
{
    public class LocationController : MasterController
    {

        private const int MAX_RESULTS = 10;
        //
        // GET: /Location/
        [HttpGet]
        public JsonResult AllLocations(int currentPage)
        {
            return Json(TrackHelper.GetAllLocations(currentPage * MAX_RESULTS, ((currentPage * MAX_RESULTS) + MAX_RESULTS - 1)), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult SearchStateLocations(string state,int currentPage)
        {
            return Json(TrackHelper.SearchStateLocations(state, currentPage * MAX_RESULTS, ((currentPage * MAX_RESULTS) + MAX_RESULTS - 1)), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult SearchDistance(string zip, int distance,int currentPage) 
        {
            var qualifiedLocations = TrackHelper.FindLocationsInDistance(zip, distance, currentPage * MAX_RESULTS, ((currentPage * MAX_RESULTS) + MAX_RESULTS - 1));
            return Json(qualifiedLocations, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Authorize]
        public JsonResult AddLocation(NewTrackModel newLocation)
        {
            if (ModelState.IsValid)
            {
                int trackId = TrackHelper.AddTrack(newLocation);
                return Json(String.Format("{0}/{1}", Constants.PathConstants.Pages.TrackReviewPath, trackId));
                
            }
            return Json("Errors");//get error collection
        }

        [HttpPost]
        [Authorize]
        public JsonResult ApproveTracks(ApprovedModel newLocation)
        {
         
            return Json(newLocation);//get error collection
        }

        public class ApprovedModel {
            public string[] ApprovedIds { get; set; }
        }
    }
}
