using System.Web.Mvc;
using UCDMvcBootCamp.Core.Domain;

namespace UCDMvcBootCamp.Controllers
{
    public class HomeController : ApplicationController
    {
        // GET: /

        public ActionResult Index()
        {
            var conferences = Repository.OfType<Conference>().GetAll();

            return Content("Testing 123");
        }

    }
}
