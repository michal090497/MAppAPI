using MApp.DataAccess.Context;
using MApp.DataAccess.DataModifiers.EventsModifiersBase;
using MApp.DataAccess.Models.PhysicalEvents;
using MApp.DataAccess.Models.Users;

namespace MApp.DataAccess.DataModifiers.PhysicalEventsModifiers
{
    public class PhysicalEventAttendeesModifier : DataModifierBase, IEventAttendeesModifierBase<PhysicalEvent>
    {
        public PhysicalEventAttendeesModifier(MAppDbContext dbContext) : base(dbContext) { }
        public async Task AddAttendee(PhysicalEvent physicalEvent, User user, bool isUserAttending)
        {
            var attendee = new PhysicalEventAttendee
            {
                IsAttending = isUserAttending,
                UpdateTime = DateTime.UtcNow,
                User = user
            };
            physicalEvent.Attendees.Add(attendee);
            physicalEvent.SpotsLeft--;
            await dbContext.SaveChangesAsync();
        }
    }
}
