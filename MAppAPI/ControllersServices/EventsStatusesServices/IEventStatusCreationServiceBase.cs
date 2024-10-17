using MApp.DataAccess.DataAccessors.AccesorsBase;
using MApp.DataAccess.DataAccessors.UsersAccessors;
using MApp.DataAccess.DataModifiers.EventsStatusesModifiers;
using MApp.DataAccess.Models.EventsBase;
using MApp.DataAccess.Models.EventsStatuses;
using MAppAPI.Models.Requests.EventsStatuses;

namespace MAppAPI.ControllersServices.EventsStatusesServices
{
    public interface IEventStatusCreationServiceBase<EventAccessorType, EventType>
        where EventAccessorType : IEventsAccesor<EventType>
        where EventType : IEventBase
    {
        UserAccessor userAccessor { get; }
        EventStatusModifier eventStatusCreator { get; }
        EventAccessorType eventAccessor { get; }
        public async Task<ICollection<EventStatus>> TryCreateEventStatusAsync(CreateEventsStatusRequest createEventsStatusRequest, int userID) { return null; }
    }
}
