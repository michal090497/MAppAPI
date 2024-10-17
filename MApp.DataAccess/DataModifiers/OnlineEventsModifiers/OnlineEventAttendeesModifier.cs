using MApp.DataAccess.Context;
using MApp.DataAccess.DataModifiers.EventsModifiersBase;
using MApp.DataAccess.Models.OnlineEvents;
using MApp.DataAccess.Models.Users;

namespace MApp.DataAccess.DataModifiers.OnlineEventsModifiers
{
    public class OnlineEventAttendeesModifier : DataModifierBase, IEventAttendeesModifierBase<OnlineEvent>
    {
        public OnlineEventAttendeesModifier(MAppDbContext dbContext) : base(dbContext) { }
        public async Task AddAttendee(OnlineEvent onlineEvent, User user, bool isUserAttending)
        {
            var attendee = new OnlineEventAttendee
            {
                IsAttending = isUserAttending,
                UpdateTime = DateTime.UtcNow,
                User = user
            };
            onlineEvent.Attendees.Add(attendee);
            onlineEvent.SpotsLeft--;
            await dbContext.SaveChangesAsync();
        }
    }
}
