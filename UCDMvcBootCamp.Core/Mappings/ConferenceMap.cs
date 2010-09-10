using FluentNHibernate.Mapping;
using UCDMvcBootCamp.Core.Domain;

namespace UCDMvcBootCamp.Core.Mappings
{
    public class ConferenceMap : ClassMap<Conference>
    {
        public ConferenceMap()
        {
            Id(x => x.Id);

            Map(x => x.Name);
            Map(x => x.AttendeeCount);
            Map(x => x.SessionCount);

            HasMany(x => x.Attendees).Cascade.AllDeleteOrphan();
            HasMany(x => x.Sessions).Cascade.AllDeleteOrphan();

        }
    }
}
