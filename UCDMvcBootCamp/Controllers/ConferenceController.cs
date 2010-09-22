using System;
using System.Linq;
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

        [HandleError(View = "NoConferenceError", ExceptionType = typeof(ArgumentOutOfRangeException))]
        public ActionResult Show(string confname)
        {
            //Get the conference
            var conference = _conferenceRepository.Queryable.Where(x => x.Name == confname).SingleOrDefault();

            if (conference == null)
            {
                throw new ArgumentOutOfRangeException("Conference Name Not Found: " + confname);
            }

            //Map to a show model
            var model = new ConferenceShowModel
                            {
                                Name = conference.Name,
                                Sessions = conference.Sessions.Select(
                                    x =>
                                    new ConferenceShowModel.SessionShowModel
                                        {
                                            Title = x.Title,
                                            SpeakerFirstName = x.Speaker.FirstName,
                                            SpeakerLastName = x.Speaker.LastName
                                        }
                                    ).ToList()
                            };

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

    }
}
