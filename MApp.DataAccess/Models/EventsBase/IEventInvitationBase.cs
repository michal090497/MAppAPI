using MApp.DataAccess.Models.Users;

namespace MApp.DataAccess.Models.EventsBase
{
    public interface IEventInvitationBase<out EventType> : IEntityBase
        where EventType : IEventBase
    {
        public User InvitedUser { get; }
        public int AuthorID { get; }
        public DateTime InvitationTime { get; }
        public EventType Event { get; }
    }
}
