using MApp.DataAccess.DataAccessors.AccesorsBase;
using MApp.DataAccess.DataAccessors.UsersAccessors;
using MApp.DataAccess.DataModifiers.EventsModifiersBase;
using MApp.DataAccess.Models.EventsBase;
using MAppAPI.Models.Requests;
using MAppAPI.Models.Requests.Users;

namespace MAppAPI.ControllersServices.EventsServicesBase
{
    public interface IEventAttendeesServiceBase<EventInvitationAccessorType, EventAttendeesMofifierType, EventInvitationsModifierType, EventAccessorType, InvitationType, EventType>
        where EventInvitationAccessorType : IEventsInvitationsAccessor<InvitationType, EventType>
        where EventAttendeesMofifierType : IEventAttendeesModifierBase<EventType>
        where EventInvitationsModifierType : IEventInvitationsModifierBase<EventType, InvitationType>
        where EventAccessorType : IEventsAccesor<EventType>
        where InvitationType : IEventInvitationBase<EventType>
        where EventType : IEventBase
    {
        EventInvitationAccessorType invitationAccessor { get; }
        EventAttendeesMofifierType attendeesModifier { get; }
        EventInvitationsModifierType invitationsModifier { get; }
        UserAccessor userAccessor { get; }
        EventAccessorType eventAccessor { get; }
        public Task<EventType?> TryAttendEventAsync(EventSignUpRequest signUp, int userID) { return null; }
        public async Task<string> TryHandleInvitationAsync(ContactInvitationResponseRequest responseRequest, int userID) { return string.Empty; }
        public async Task<string> TryCreateInvitationAsync(EventInvitationRequest invitationRequest, int userID) { return string.Empty; }
    }
}
