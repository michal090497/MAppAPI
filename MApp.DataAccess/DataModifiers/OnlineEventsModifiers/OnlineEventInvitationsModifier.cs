using MApp.DataAccess.Context;
using MApp.DataAccess.DataModifiers.EventsModifiersBase;
using MApp.DataAccess.Models.OnlineEvents;
using MApp.DataAccess.Models.Users;

namespace MApp.DataAccess.DataModifiers.OnlineEventsModifiers
{
    public class OnlineEventInvitationsModifier : DataModifierBase, IEventInvitationsModifierBase<OnlineEvent, OnlineEventInvitation>
    {
        public OnlineEventInvitationsModifier(MAppDbContext dbContext) : base(dbContext) { }
        public async Task RemoveInvitation(OnlineEventInvitation invitation)
        {
            invitation.Event.InvitedUsers.Remove(invitation);
            invitation.InvitedUser.OnlineEventsInvitations.Remove(invitation);
            await dbContext.SaveChangesAsync();
        }
        public async Task CreateInvitation(OnlineEvent tempEvent, User invitedUser, int authorID)
        {
            var eventInvitation = new OnlineEventInvitation
            {
                Event = tempEvent,
                InvitedUser = invitedUser,
                AuthorID = authorID,
                InvitationTime = DateTime.UtcNow
            };
            dbContext.OnlineEventsInvitations.Add(eventInvitation);
            await dbContext.SaveChangesAsync();
        }
    }
}
