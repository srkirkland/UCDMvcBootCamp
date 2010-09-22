using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
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
            var conferences = _conferenceRepository.GetAll();

            //Transform the conferences into a listModel
            var model = Mapper.Map<IList<Conference>, List<ConferenceListModel>>(conferences);

            return Xml(model);
            //return new XmlResult<List<ConferenceListModel>> { Model = model.ToList() };
        }
    }
}
