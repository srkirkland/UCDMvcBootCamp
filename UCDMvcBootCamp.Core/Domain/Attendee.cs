using UCDArch.Core.DomainModel;

namespace UCDMvcBootCamp.Core.Domain
{
    public class Attendee : DomainObject
    {
        public Attendee(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public Attendee() { }

        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Email { get; set; }

        public virtual Conference Conference { get; set; }

        public virtual void ChangeName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public virtual void RegisterFor(Conference conference)
        {
            Conference = conference;
            conference.AddAttendee(this);
        }
    }
}
