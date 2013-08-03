using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MappingSearch.Controllers
{
    public class AddLocationController : MasterController
    {
        //
        // GET: /AddLocation/
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

    }
}
