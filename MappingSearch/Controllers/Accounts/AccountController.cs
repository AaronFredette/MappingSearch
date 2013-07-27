using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MappingSearch.Classes.Account;
using MappingSearch.Models.Account;
using MappingSearch.Classes;

namespace MappingSearch.Controllers
{
    public class AccountController : MasterController
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Create(CreateAccountModel model,string returnUrl)
        {
            if (ModelState.IsValid && String.Equals(model.Password, model.ConfirmPassword))
            {
                Dictionary<string, string> errors= AccountHelper.CreatAccount(model);
                if (errors.Count ==0)
                {
                    returnUrl = String.IsNullOrEmpty(returnUrl) ? "/Account/" : returnUrl;
                    return RedirectToRoute(returnUrl);
                }

                foreach (var err in errors)
                {
                    ModelState.AddModelError(err.Key, err.Value);
                }
                return View(model);
            }

            return View(model);
        }


        [HttpPost]
        [Authorize]
        public ActionResult Logout() 
        {
            FormsAuthentication.SignOut();
            CurrentUser.LogOut();
            return Redirect("/Home");
        }

        //
        // GET: /Account/
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
           
            if (ModelState.IsValid)
            {
                bool sucess = AccountHelper.LogIn(model.UserName, model.Password);
                
                if (sucess) 
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);

                    returnUrl = String.IsNullOrEmpty(returnUrl) ? "/Account" : returnUrl;
                    return Redirect(returnUrl);
                }
                ModelState.AddModelError("InValidLogin", "The user name and password you've entered are invalid.");
            }
            return View(model);
        }
    }
}
