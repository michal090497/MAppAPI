using MApp.DataAccess.DataAccessors.PhysicalEventsAccessors;
using MApp.DataAccess.DataAccessors.UsersAccessors;
using MApp.DataAccess.Models.PhysicalEvents;
using MAppAPI.ControllersServices.EventsServicesBase;

namespace MAppAPI.ControllersServices.PhysicalEventsServices
{
    public class PhysicalEventInfoService : IEventInfoServiceBase<PhysicalEventAccessor, PhysicalEvent>
    {
        public UserAccessor userAccessor { get; set; }
        public PhysicalEventAccessor eventAccessor { get; set; }
        public PhysicalEventInfoService(UserAccessor userAccessor, PhysicalEventAccessor eventAccessor)
        {
            this.userAccessor = userAccessor;
            this.eventAccessor = eventAccessor;
        }
        public async Task<PhysicalEvent> TryGetInfoWithDetailsAsync(int eventID, int userID)
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
