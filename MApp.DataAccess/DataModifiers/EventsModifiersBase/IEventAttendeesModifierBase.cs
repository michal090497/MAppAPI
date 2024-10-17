using MApp.DataAccess.Models.EventsBase;
using MApp.DataAccess.Models.Users;

namespace MApp.DataAccess.DataModifiers.EventsModifiersBase
{
    public interface IEventAttendeesModifierBase<EventType> : IDataModifierBase 
        where EventType : IEventBase
    {
        public async Task AddAttendee(EventType Event, User user, bool isUserAttending) { }
    }
}
