using MApp.DataAccess.DataAccessors.OnlineEventsAccessors;
using MApp.DataAccess.DataAccessors.UsersAccessors;
using MApp.DataAccess.Models.OnlineEvents;
using MAppAPI.ControllersServices.EventsServicesBase;

namespace MAppAPI.ControllersServices.OnlineEventsServices
{
    public class OnlineEventInfoService : IEventInfoServiceBase<OnlineEventAccessor, OnlineEvent>
    {
        public UserAccessor userAccessor { get; set; }
        public OnlineEventAccessor eventAccessor { get; set; }
        public OnlineEventInfoService(UserAccessor userAccessor, OnlineEventAccessor eventAccessor)
        {
            this.userAccessor = userAccessor;
            this.eventAccessor = eventAccessor;
        }
        public async Task<OnlineEvent> TryGetInfoWithDetailsAsync(int eventID, int userID)
        {
            await userAccessor.FindEntity(userID);
            if (userAccessor.User == null)
                return null;
            await eventAccessor.FindEntityWithDetailedAssocs(eventID);
            if (eventAccessor.Event == null || !eventAccessor.Event.Users.Any(x => x.ID == userID))
                return null;
            return eventAccessor.Event;
        }
    }
}
