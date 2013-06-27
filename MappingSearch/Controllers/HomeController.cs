using System.Web.Mvc;

namespace MappingSearch.Controllers
{
    public class HomeController : MasterController
    {
        //
        // GET: /Home/
      
        public ActionResult Index()
        {
            return View();
        }

    }
}
