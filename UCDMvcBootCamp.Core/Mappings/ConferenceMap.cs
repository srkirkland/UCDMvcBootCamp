using FluentNHibernate.Mapping;
using UCDMvcBootCamp.Core.Domain;

namespace UCDMvcBootCamp.Core.Mappings
{
    public class ConferenceMap : ClassMap<Conference>
    {
        public ConferenceMap()
        {
            Table("Conferences");

            Id(x => x.Id).GeneratedBy.Identity();

            Map(x => x.Name);
            Map(x => x.AttendeeCount);
            Map(x => x.SessionCount);

            HasMany(x => x.Attendees).KeyColumn("ConferenceID").Cascade.AllDeleteOrphan();
            HasMany(x => x.Sessions).KeyColumn("ConferenceID").Cascade.AllDeleteOrphan();

        }
    }
}
