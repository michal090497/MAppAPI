using MApp.DataAccess.Models.EventsBase;

namespace MApp.DataAccess.DataAccessors.AccesorsBase
{
    public interface IEventsInvitationsAccessor<InvitationType, EventType> : IDataAccessor 
        where InvitationType : IEventInvitationBase<EventType> 
        where EventType : IEventBase
    {
        public InvitationType EventInvitation { get; }
    }
}
