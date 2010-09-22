using AutoMapper;
using UCDMvcBootCamp.Core.Domain;
using UCDMvcBootCamp.Models;

namespace UCDMvcBootCamp.Helpers
{
    public class AutoMapperBootstrapper
    {
        public static void Init()
        {
            Mapper.Initialize(cfg => cfg.AddProfile<ViewModelProfile>());
        }
    }

    public class ViewModelProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Conference, ConferenceListModel>();
            CreateMap<Conference, ConferenceShowModel>();
            CreateMap<Session, ConferenceShowModel.SessionShowModel>();
            CreateMap<Attendee, AttendeeListModel>();
        }
    }
}