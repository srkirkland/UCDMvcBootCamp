using FluentNHibernate.Mapping;
using UCDMvcBootCamp.Core.Domain;

namespace UCDMvcBootCamp.Core.Mappings
{
    public class AttendeeMap : ClassMap<Attendee>
    {
        public AttendeeMap()
        {
            Id(x => x.Id);

            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.Email);
            
            References(x=>x.Conference);
        }
    }
}
