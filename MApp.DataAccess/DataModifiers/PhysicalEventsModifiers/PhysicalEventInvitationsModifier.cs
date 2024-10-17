using MApp.DataAccess.Context;
using MApp.DataAccess.DataModifiers.EventsModifiersBase;
using MApp.DataAccess.Models.PhysicalEvents;
using MApp.DataAccess.Models.Users;

namespace MApp.DataAccess.DataModifiers.PhysicalEventsModifiers
{
    public class PhysicalEventInvitationsModifier : DataModifierBase, IEventInvitationsModifierBase<PhysicalEvent, PhysicalEventInvitation>
    {
        public PhysicalEventInvitationsModifier(MAppDbContext dbContext) : base(dbContext) { }
        public async Task RemoveInvitation(PhysicalEventInvitation invitation)
        {
            invitation.Event.InvitedUsers.Remove(invitation);
            invitation.InvitedUser.PhysicalEventsInvitations.Remove(invitation);
            await dbContext.SaveChangesAsync();
        }
        public async Task CreateInvitation(PhysicalEvent tempEvent, User invitedUser, int authorID)
        {
            var eventInvitation = new PhysicalEventInvitation
            {
                Event = tempEvent,
                InvitedUser = invitedUser,
                AuthorID = authorID,
                InvitationTime = DateTime.UtcNow
            };
            dbContext.PhysicalEventsInvitations.Add(eventInvitation);
            await dbContext.SaveChangesAsync();
        }
    }
}
