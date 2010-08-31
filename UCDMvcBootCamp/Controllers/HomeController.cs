using System.Linq;
using System.Web.Mvc;
using UCDMvcBootCamp.Core.Domain;

namespace UCDMvcBootCamp.Controllers
{
    public class HomeController : ApplicationController
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
