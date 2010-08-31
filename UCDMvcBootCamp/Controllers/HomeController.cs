using System.Linq;
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

            var attendeesforfirstconf = conferences.First().Attendees.ToList();
            var sessionsforfirstconf = conferences.First().Sessions.ToList();
            
            return Content("Testing 123");
        }

    }
}
