using MApp.DataAccess.Context;
using MApp.DataAccess.DataModifiers.EventsModifiersBase;
using MApp.DataAccess.Models.OnlineEvents;
using MApp.DataAccess.Models.Users;

namespace MApp.DataAccess.DataModifiers.OnlineEventsModifiers
{
    public class OnlineEventCreator : DataModifierBase, IEventCreatorBase
    {
        public OnlineEventCreator(MAppDbContext dbContext) : base(dbContext) { }
        public async Task<bool> CreateDbObject
            (User user, int categoryID, string eventTitle, string eventDescription, int spotsLeft, bool isUsersListPublic, bool isEventPrivate, string subcategory, string details, string wayOfContact, string contactDetails, DateTime eventDate)
        {
            var tempCat = dbContext.OnlineEventCategories.Where(x => x.ID == categoryID).FirstOrDefault();
            if (tempCat == null)
                return false;
            OnlineEvent onlineEvent = new OnlineEvent
            {
                EventTitle = eventTitle,
                EventDescription = eventDescription,
                SpotsLeft = spotsLeft,
                Spots = spotsLeft + 1,
                Category = tempCat,
                CreatorID = user.ID,
                IsUsersListPublic = isUsersListPublic,
                IsEventPrivate = isEventPrivate,
                Subcategory = subcategory,
                EventDate = eventDate,
                Details = new OnlineEventDetails
                {
                    Details = details,
                    WayOfContact = wayOfContact,
                    ContactDetails = contactDetails
                }
            };
            var attendee = new OnlineEventAttendee
            {
                IsAttending = true,
                UpdateTime = DateTime.UtcNow,
                User = user
            };
            onlineEvent.Attendees.Add(attendee);
            dbContext.OnlineEvents.Add(onlineEvent);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
