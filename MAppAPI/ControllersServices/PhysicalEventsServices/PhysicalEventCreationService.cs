using GeoTimeZone;
using MApp.DataAccess.DataAccessors.UsersAccessors;
using MApp.DataAccess.DataModifiers.PhysicalEventsModifiers;
using MAppAPI.ControllersServices.EventsServicesBase;
using MAppAPI.Models.Requests.PhysicalEvents;
using TimeZoneConverter;

namespace MAppAPI.ControllersServices.PhysicalEventsServices
{
    public class PhysicalEventCreationService : IEventCreationServiceBase<PhysicalEventCreator, PhysicalEventRequest>
    {
        public PhysicalEventCreator eventCreator { get; set; }
        public UserAccessor userAccessor { get; set; }
        public PhysicalEventCreationService(PhysicalEventCreator eventCreator, UserAccessor userAccessor)
        {
            this.eventCreator = eventCreator;
            this.userAccessor = userAccessor;
        }
        public async Task<bool> TryCreateEventAsync(PhysicalEventRequest eventRequest, int userID)
        {
            await userAccessor.FindEntity(userID);
            if (userAccessor.User == null)
                return false;
            var eventDate = TimeZoneInfo.ConvertTimeToUtc(eventRequest.EventDate, TimeZoneInfo.Local);
            string tz = TimeZoneLookup.GetTimeZone(eventRequest.Latitude, eventRequest.Longtitude).Result;
            var converted = TZConvert.IanaToWindows(tz);
            var x = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(eventRequest.EventDate, converted);
            var timeDiff = x - eventDate;
            var eventDateGMT = TimeZoneInfo.ConvertTimeToUtc(eventDate - (TimeSpan)timeDiff, TimeZoneInfo.Local);
            return await eventCreator.CreateDbObject(userAccessor.User, eventRequest.CategoryID, eventRequest.EventTitle, eventRequest.EventDescription, eventRequest.Longtitude, eventRequest.Latitude, eventRequest.SpotsLeft,
                eventRequest.IsUsersListPublic, eventRequest.IsEventPrivate, eventRequest.Subcategory, eventRequest.Details, eventRequest.WayOfContact, eventRequest.ContactDetails, eventRequest.HowToGetThereInfo, TimeZoneInfo.ConvertTimeToUtc(eventRequest.EventDate, TimeZoneInfo.Local).AddHours(1), eventDateGMT);
        }
    }
}
