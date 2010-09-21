using System.Collections.Generic;

namespace UCDMvcBootCamp.Models
{
    public class ConferenceShowModel
    {
        public string Name { get; set; }

        public IList<SessionShowModel> Sessions { get; set; }

        public class SessionShowModel
        {
            public string Title { get; set; }
            public string SpeakerFirstName { get; set; }
            public string SpeakerLastName { get; set; }
        }
    }
}