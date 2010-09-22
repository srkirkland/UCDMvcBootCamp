using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UCDArch.Core.PersistanceSupport;
using UCDMvcBootCamp.Core.Domain;
using UCDMvcBootCamp.Models;
using AutoMapper;

namespace UCDMvcBootCamp.Controllers
{
    public class AttendeeController : ApplicationController
    {
        private readonly IRepository<Conference> _conferenceRepository;

        public AttendeeController(IRepository<Conference> conferenceRepository)
        {
            _conferenceRepository = conferenceRepository;
        }

        //
        // GET: /Attendee/
        public ActionResult Show(string confName)
        {
            var conference = _conferenceRepository.Queryable.Where(x => x.Name == confName).Single();

            var model = Mapper.Map<IList<Attendee>, List<AttendeeListModel>>(conference.Attendees);

            return View(model);
        }

    }
}
