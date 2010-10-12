using System.Linq;
using System.Web.Mvc;
using UCDMvcBootCamp.Core.Domain;
using UCDMvcBootCamp.Models;

namespace UCDMvcBootCamp.Controllers
{
    public class HomeController : ApplicationController
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult Verify()
        {
            var model = new VerificationModel();
            var conferenceRepository = Repository.OfType<Conference>();

            model.InitialConferenceCount = conferenceRepository.Queryable.Count();

            var newConf = new Conference("NewConf");

            //Create a new conference
            conferenceRepository.EnsurePersistent(newConf);

            model.NewConferenceCount = conferenceRepository.Queryable.Count();

            //Delete that conference
            conferenceRepository.Remove(newConf);

            model.RemovedConferenceCount = conferenceRepository.Queryable.Count();

            return View(model);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
