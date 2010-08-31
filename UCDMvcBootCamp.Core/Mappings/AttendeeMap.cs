using FluentNHibernate.Mapping;
using UCDMvcBootCamp.Core.Domain;

namespace UCDMvcBootCamp.Core.Mappings
{
    public class AttendeeMap : ClassMap<Attendee>
    {
        public AttendeeMap()
        {
            Table("Attendees");
            Id(x => x.Id).GeneratedBy.Identity();

            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.Email);
            
            References(x=>x.Conference);
        }
    }
}
