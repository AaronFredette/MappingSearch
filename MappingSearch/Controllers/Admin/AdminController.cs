﻿using MappingSearch.Classes;
using MappingSearch.Classes.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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


        [Authorize]
        public ActionResult UnapprovedTracks()
        {
            if (CurrentUser.AdminLevel() == 99)
            {
                var model = ProductAdminHelper.GetAllUnapprovedTracks();
                return View(model);
            }
            else
            {
                return Redirect("/");
            }

        }


       
        [Authorize]
        public ActionResult Unapproved()
        {
            if (CurrentUser.AdminLevel() == 99)
            {
                var model = ProductAdminHelper.GetAllUnapprovedProducts();
                return View(model);
            }

            return Redirect("/");
        }

        [Authorize]
        public ActionResult CalculateAverageTask()
        {
            if (CurrentUser.AdminLevel() == 99)
            {
                ReviewsAdminHelper.CalculateAverageReviewsProducts();
                return View();
            }
            else
            {

                return Redirect("/");
            }
        }

    }
}
