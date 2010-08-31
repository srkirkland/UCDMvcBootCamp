using UCDArch.Core.DomainModel;

namespace UCDMvcBootCamp.Core.Domain
{
    public class Session : DomainObject
    {
        public Session(string title, string @abstract, Speaker speaker)
        {
            Title = title;
            Abstract = @abstract;
            Speaker = speaker;

            speaker.Register(this);
        }

        protected Session() { }

        public virtual string Title { get; set; }
        public virtual string Abstract { get; set; }
        public virtual Speaker Speaker { get; set; }
        public virtual Conference Conference { get; set; }
    }
}

