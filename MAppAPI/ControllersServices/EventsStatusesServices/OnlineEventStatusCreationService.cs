using MApp.DataAccess.DataAccessors.OnlineEventsAccessors;
using MApp.DataAccess.DataAccessors.UsersAccessors;
using MApp.DataAccess.DataModifiers.EventsStatusesModifiers;
using MApp.DataAccess.Models.EventsStatuses;
using MApp.DataAccess.Models.OnlineEvents;
using MAppAPI.Models.Requests.EventsStatuses;

namespace MAppAPI.ControllersServices.EventsStatusesServices
{
    public class OnlineEventStatusCreationService : IEventStatusCreationServiceBase<OnlineEventAccessor, OnlineEvent>
    {
        public UserAccessor userAccessor { get; set; }
        public OnlineEventAccessor eventAccessor { get; set; }
        public EventStatusModifier eventStatusCreator { get; set; }
        public OnlineEventStatusCreationService(UserAccessor userAccessor, OnlineEventAccessor eventAccessor, EventStatusModifier eventStatusCreator)
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
