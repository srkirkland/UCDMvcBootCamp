using FluentNHibernate.Mapping;
using UCDMvcBootCamp.Core.Domain;

namespace UCDMvcBootCamp.Core.Mappings
{
    public class SpeakerMap : ClassMap<Speaker>
    {
        public SpeakerMap()
        {
            Table("Speakers");

            Id(x => x.Id).GeneratedBy.Identity();

            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.Bio);

            HasMany(x => x.Sessions).KeyColumn("SpeakerID");
        }
    }
}
