using MApp.DataAccess.Context;
using MApp.DataAccess.DataModifiers.EventsModifiersBase;
using MApp.DataAccess.Models.PhysicalEvents;
using MApp.DataAccess.Models.Users;

namespace MApp.DataAccess.DataModifiers.PhysicalEventsModifiers
{
    public class PhysicalEventCreator : DataModifierBase, IEventCreatorBase
    {
        public PhysicalEventCreator(MAppDbContext dbContext) : base(dbContext) { }
        public async Task<bool> CreateDbObject
            (User user, int categoryID, string eventTitle, string eventDescription, double longtitude, double latitude, int spotsLeft, bool isUsersListPublic, bool isEventPrivate, string subcategory, string details, string wayOfContact, string contactDetails, string howToGetThereInfo, DateTime eventDate, DateTime eventDateGMT)
        {
            var tempCat = dbContext.PhysicalEventCategories.Where(x => x.ID == categoryID).FirstOrDefault();
            if (tempCat == null)
                return false;
            PhysicalEvent physicalEvent = new PhysicalEvent
            {
                EventTitle = eventTitle,
                EventDescription = eventDescription,
                Longtitude = longtitude,
                Latitude = latitude,
                SpotsLeft = spotsLeft,
                Spots = spotsLeft + 1,
                Category = tempCat,
                Subcategory = subcategory,
                CreatorID = user.ID,
                IsUsersListPublic = isUsersListPublic,
                IsEventPrivate = isEventPrivate,
                EventDate = eventDate,
                EventDateGMT = eventDateGMT,
                Details = new PhysicalEventDetails
                {
                    Details = details,
                    WayOfContact = wayOfContact,
                    ContactDetails = contactDetails,
                    HowToGetThereInfo = howToGetThereInfo
                }
            };
            var attendee = new PhysicalEventAttendee
            {
                IsAttending = true,
                UpdateTime = DateTime.UtcNow,
                User = user
            };
            physicalEvent.Attendees.Add(attendee);
            dbContext.PhysicalEvents.Add(physicalEvent);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
