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
            var conferences = _conferenceRepository.Queryable.Where(x => x.SessionCount >= minSessions);
            
            //Transform the conferences into a listModel
            var model =
                conferences.Select(
                    x =>
                    new ConferenceListModel
                        {Id = x.Id, Name = x.Name, AttendeeCount = x.AttendeeCount, SessionCount = x.SessionCount});

            return View(model.ToList());
        }

        public ActionResult Edit(int id)
        {
            var conference = _conferenceRepository.GetNullableById(id);

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

    }
}
