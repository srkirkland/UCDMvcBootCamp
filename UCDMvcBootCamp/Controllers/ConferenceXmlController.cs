using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UCDArch.Core.PersistanceSupport;
using UCDMvcBootCamp.Core.Domain;
using UCDMvcBootCamp.Helpers;
using UCDMvcBootCamp.Models;

namespace UCDMvcBootCamp.Controllers
{
    public class ConferenceXmlController : ApplicationController
    {
        private readonly IRepository<Conference> _conferenceRepository;

        public ConferenceXmlController(IRepository<Conference> conferenceRepository)
        {
            _conferenceRepository = conferenceRepository;
        }

        //
        // GET: /ConferenceXml/
        public ActionResult Xml()
        {
            //Grab all conferences
            var conferences = _conferenceRepository.Queryable;

            //Transform the conferences into a listModel
            var model =
                conferences.Select(
                    x =>
                    new ConferenceListModel { Id = x.Id, Name = x.Name, AttendeeCount = x.AttendeeCount, SessionCount = x.SessionCount });

            return Xml(model.ToList());
            //return new XmlResult<List<ConferenceListModel>> { Model = model.ToList() };
        }
    }
}
