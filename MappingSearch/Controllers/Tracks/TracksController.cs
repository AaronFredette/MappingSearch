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

    }
}
