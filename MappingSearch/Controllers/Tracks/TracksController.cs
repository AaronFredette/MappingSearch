using MappingSearch.Classes;
using MappingSearch.Classes.Reviews;
using MappingSearch.Classes.Track;
using MappingSearch.Models.ViewModels.Tracks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MappingSearch.Controllers.Tracks
{
    public class TracksController : MasterController
    {
        //
        // GET: /Tracks/

        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Review(int id)
        {
            Location loc = TrackHelper.GetTrackDetails(id);
            if (loc != null)
            {
                TrackReviewModel model = new TrackReviewModel() { TrackDetails = loc };
                model.UserHasReviewed = System.Web.HttpContext.Current.User.Identity.IsAuthenticated ? ReviewHelper.UserHasReviewedTrack(id) : false;
                return View(model);

            }
            return View("~/Views/TrackNotFound.cshtml");
        }

    }
}
