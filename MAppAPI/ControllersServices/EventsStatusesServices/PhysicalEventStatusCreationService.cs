using MApp.DataAccess.DataAccessors.PhysicalEventsAccessors;
using MApp.DataAccess.DataAccessors.UsersAccessors;
using MApp.DataAccess.DataModifiers.EventsStatusesModifiers;
using MApp.DataAccess.Models.EventsStatuses;
using MApp.DataAccess.Models.PhysicalEvents;
using MAppAPI.Models.Requests.EventsStatuses;

namespace MAppAPI.ControllersServices.EventsStatusesServices
{
    public class PhysicalEventStatusCreationService : IEventStatusCreationServiceBase<PhysicalEventAccessor, PhysicalEvent>
    {
        public UserAccessor userAccessor { get; set; }
        public PhysicalEventAccessor eventAccessor { get; set; }
        public EventStatusModifier eventStatusCreator { get; set; }
        public PhysicalEventStatusCreationService(UserAccessor userAccessor, PhysicalEventAccessor eventAccessor, EventStatusModifier eventStatusCreator)
        {
            this.userAccessor = userAccessor;
            this.eventAccessor = eventAccessor;
            this.eventStatusCreator = eventStatusCreator;
        }
        public async Task<ICollection<EventStatus>> TryCreateEventStatusAsync(CreateEventsStatusRequest createEventsStatusRequest, int userID)
        {
            await userAccessor.FindEntity(userID);
            if (userAccessor.User == null)
                return null;
            await eventAccessor.FindEntityWithDetailedAssocs(createEventsStatusRequest.EventID);
            if (eventAccessor.Event == null || !eventAccessor.Event.Users.Any(x => x.ID == userID))
                return null;
            await eventStatusCreator.Create(eventAccessor.Event, createEventsStatusRequest.Content, userAccessor.User);
            return eventAccessor.Event.Statuses;
        }
    }
}
