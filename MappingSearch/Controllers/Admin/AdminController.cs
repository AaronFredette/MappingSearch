using MappingSearch.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MappingSearch.Controllers.Admin
{
    public class AdminController : MasterController
    {
        //
        // GET: /Admin/
        [Authorize]
        public ActionResult Index()
        {
            if (CurrentUser.AdminLevel() == 99)
            {
                return View();
            }
            else 
            {
                return Redirect("/");
            }
            
        }

    }
}
