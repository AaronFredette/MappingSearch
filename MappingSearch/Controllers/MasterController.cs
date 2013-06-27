using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MappingSearch.Controllers
{
    public class MasterController : Controller
    {

        public MasterController() {
            bool isAuth = System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            ViewBag.LoggedIn = isAuth;
            ViewBag.CurrentUser = System.Web.HttpContext.Current.User.Identity.Name;
        }
    }
}
