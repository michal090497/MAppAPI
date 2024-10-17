using MApp.DataAccess.Models.EventsStatuses;

namespace MApp.DataAccess.DataAccessors.AccesorsBase
{
    public interface IEventStatusAccessor : IDataAccessor
    {
        public EventStatus UserStatus { get; }
    }
}
