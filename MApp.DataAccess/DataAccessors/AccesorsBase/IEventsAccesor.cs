using MApp.DataAccess.Models.EventsBase;

namespace MApp.DataAccess.DataAccessors.AccesorsBase
{
    public interface IEventsAccesor<EventType> : IDataAccessor 
        where EventType : IEventBase
    {
        public EventType Event { get; }
    }
}
