using MApp.DataAccess.DataAccessors.UsersAccessors;
using MApp.DataAccess.DataModifiers.EventsModifiersBase;
using MAppAPI.Models.Requests.EventsBase;

namespace MAppAPI.ControllersServices.EventsServicesBase
{
    public interface IEventCreationServiceBase<EventCreatorType, EventRequestType>
        where EventCreatorType : IEventCreatorBase
        where EventRequestType : IEventRequest
    {
        EventCreatorType eventCreator {  get; }
        UserAccessor userAccessor { get; }
        public async Task<bool> TryCreateEventAsync(EventRequestType eventRequest, int userID) { return false; }
    }
}
