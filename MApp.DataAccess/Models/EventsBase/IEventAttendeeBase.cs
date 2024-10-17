using MApp.DataAccess.Models.Users;

namespace MApp.DataAccess.Models.EventsBase
{
    public interface IEventAttendeeBase<EventType> : IEntityBase
        where EventType : IEventBase
    {
        public DateTime? UpdateTime { get; }
        public bool IsAttending { get; }
        public User User { get; }
        public EventType Event { get; }
    }
}
