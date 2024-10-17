using MApp.DataAccess.DataAccessors.UsersAccessors;
using MApp.DataAccess.DataModifiers.OnlineEventsModifiers;
using MAppAPI.ControllersServices.EventsServicesBase;
using MAppAPI.Models.Requests.OnlineEvents;

namespace MAppAPI.ControllersServices.OnlineEventsServices
{
    public class OnlineEventCreationService : IEventCreationServiceBase<OnlineEventCreator, OnlineEventRequest>
    {
        public OnlineEventCreator eventCreator {  get; set; }
        public UserAccessor userAccessor { get; set; }
        public OnlineEventCreationService(OnlineEventCreator eventCreator, UserAccessor userAccessor)
        {
            this.eventCreator = eventCreator;
            this.userAccessor = userAccessor;
        }
        public async Task<bool> TryCreateEventAsync(OnlineEventRequest eventRequest, int userID)
        {
            await userAccessor.FindEntity(userID);
            if (userAccessor.User == null)
                return false;
            return await eventCreator.CreateDbObject(userAccessor.User, eventRequest.CategoryID, eventRequest.EventTitle, eventRequest.EventDescription, eventRequest.SpotsLeft,
                eventRequest.IsUsersListPublic, eventRequest.IsEventPrivate, eventRequest.Subcategory, eventRequest.Details, eventRequest.WayOfContact, eventRequest.ContactDetails, TimeZoneInfo.ConvertTimeToUtc(eventRequest.EventDate, TimeZoneInfo.Local).AddHours(1));
        }
    }
}
