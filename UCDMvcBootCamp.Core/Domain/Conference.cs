using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using UCDArch.Core.DomainModel;

namespace UCDMvcBootCamp.Core.Domain
{
    public class Conference : DomainObject
    {
        public virtual IList<Attendee> Attendees { get; set; }
        public virtual IList<Session> Sessions { get; set; }

        public Conference(string name)
            : this()
        {
            Name = name;
            AttendeeCount = 0;
            SessionCount = 0;
        }

        public Conference()
        {
            Attendees = new List<Attendee>();
            Sessions = new List<Session>();
        }

        [Required]
        [StringLength(20)]
        public virtual string Name { get; set; }

        public virtual int AttendeeCount { get; set; }
        public virtual int SessionCount { get; set; }

        public virtual void ChangeName(string name)
        {
            Name = name;
        }

        public virtual IEnumerable<Attendee> GetAttendees()
        {
            return Attendees;
        }

        public virtual Attendee GetAttendee(int attendeeId)
        {
            return Attendees.First(a => a.Id == attendeeId);
        }

        public virtual void AddSession(Session session)
        {
            Sessions.Add(session);
            session.Conference = this;
            SessionCount++;
        }

        public virtual IEnumerable<Session> GetSessions()
        {
            return Sessions;
        }

        protected internal virtual void AddAttendee(Attendee attendee)
        {
            Attendees.Add(attendee);
            AttendeeCount++;
        }
    }
}