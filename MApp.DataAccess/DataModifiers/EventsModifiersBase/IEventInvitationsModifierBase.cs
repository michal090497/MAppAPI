using MApp.DataAccess.Models.EventsBase;
using MApp.DataAccess.Models.Users;

namespace MApp.DataAccess.DataModifiers.EventsModifiersBase
{
    public interface IEventInvitationsModifierBase<EventType, InvitationType> : IDataModifierBase 
        where EventType : IEventBase
        where InvitationType : IEventInvitationBase<EventType>
    {
        public async Task RemoveInvitation(InvitationType invitation) { }
        public async Task CreateInvitation(EventType tempEvent, User invitedUser, int authorID) { }
    }
}
