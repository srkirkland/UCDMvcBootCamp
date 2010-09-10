using FluentNHibernate.Mapping;
using UCDMvcBootCamp.Core.Domain;

namespace UCDMvcBootCamp.Core.Mappings
{
    public class SpeakerMap : ClassMap<Speaker>
    {
        public SpeakerMap()
        {
            Id(x => x.Id);

            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.Bio);

            HasMany(x => x.Sessions);
        }
    }
}
