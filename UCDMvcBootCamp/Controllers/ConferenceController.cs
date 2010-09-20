using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UCDArch.Core.PersistanceSupport;
using UCDMvcBootCamp.Core.Domain;
using UCDMvcBootCamp.Models;

namespace UCDMvcBootCamp.Controllers
{
    public class ConferenceController : Controller
    {
        private readonly IRepository<Conference> _conferenceRepository;

        public ConferenceController(IRepository<Conference> conferenceRepository)
        {
            _conferenceRepository = conferenceRepository;
        }

        //
        // GET: /Conference/
        public ActionResult Index()
        {
            //Grab all conferences
            var conferences = _conferenceRepository.GetAll();

            //Transform the conferences into a listModel
            var model =
                conferences.Select(
                    x =>
                    new ConferenceListModel
                        {Name = x.Name, AttendeeCount = x.AttendeeCount, SessionCount = x.SessionCount});

            return View(model);
        }

    }
}
