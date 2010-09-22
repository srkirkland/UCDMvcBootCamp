using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using UCDArch.Core.PersistanceSupport;
using UCDMvcBootCamp.Core.Domain;
using UCDMvcBootCamp.Models;

namespace UCDMvcBootCamp.Controllers
{
    public class ConferenceController : ApplicationController
    {
        private readonly IRepository<Conference> _conferenceRepository;

        public ConferenceController(IRepository<Conference> conferenceRepository)
        {
            _conferenceRepository = conferenceRepository;
        }

        //
        // GET: /Conference/
        public ActionResult Index(int minSessions = 0)
        {
            //Grab all conferences
            var conferences = _conferenceRepository.Queryable.Where(x => x.SessionCount >= minSessions).ToList();
            
            var model = Mapper.Map<List<Conference>, List<ConferenceListModel>>(conferences);

            return View(model);
        }

        [HandleError(View = "NoConferenceError", ExceptionType = typeof(ArgumentOutOfRangeException))]
        public ActionResult Show(string confname)
        {
            //Get the conference
            var conference = _conferenceRepository.Queryable.Where(x => x.Name == confname).SingleOrDefault();

            if (conference == null)
            {
                throw new ArgumentOutOfRangeException("Conference Name Not Found: " + confname);
            }

            var model = Mapper.Map<Conference, ConferenceShowModel>(conference);

            return View(model);
        }

        public ActionResult Edit(string confname)
        {
            var conference = _conferenceRepository.Queryable.Where(x=>x.Name == confname).Single();

            return View(conference);
        }

        [HttpPost]
        public ActionResult Edit(Conference conference)
        {
            var conferenceToEdit = _conferenceRepository.GetNullableById(conference.Id);

            conferenceToEdit.ChangeName(conference.Name);
            
            foreach (var attendee in conference.Attendees)
            {
                var attendeeToEdit = conferenceToEdit.GetAttendee(attendee.Id);

                attendeeToEdit.ChangeName(attendee.FirstName, attendee.LastName);
                attendeeToEdit.Email = attendee.Email;
            }

            _conferenceRepository.EnsurePersistent(conferenceToEdit);

            return RedirectToAction("Index");
        }

        [ChildActionOnly]
        public ActionResult Stats()
        {
            var model = new ConferenceStatsModel
                            {
                                ConferenceCount = _conferenceRepository.Queryable.Count(),
                                SessionCount = _conferenceRepository.Queryable.Sum(x => x.SessionCount)
                            };

            return PartialView(model);
        }
    }
}
