using MApp.DataAccess.DataAccessors.OnlineEventsAccessors;
using MApp.DataAccess.DataAccessors.OnlineEventsInvitationsAccessors;
using MApp.DataAccess.DataAccessors.UsersAccessors;
using MApp.DataAccess.DataModifiers.OnlineEventsModifiers;
using MApp.DataAccess.Models.OnlineEvents;
using MAppAPI.ControllersServices.EventsServicesBase;
using MAppAPI.Models.Requests;
using MAppAPI.Models.Requests.Users;

namespace MAppAPI.ControllersServices.OnlineEventsServices
{
    public class OnlineEventAttendeesService : IEventAttendeesServiceBase<OnlineEventInvitationAccessor, OnlineEventAttendeesModifier, OnlineEventInvitationsModifier, OnlineEventAccessor, OnlineEventInvitation, OnlineEvent>
    {
        public OnlineEventInvitationAccessor invitationAccessor {  get; set; }
        public OnlineEventAttendeesModifier attendeesModifier { get; set; }
        public OnlineEventInvitationsModifier invitationsModifier { get; set; }
        public UserAccessor userAccessor { get; set; }
        public OnlineEventAccessor eventAccessor { get; set; }
        public OnlineEventAttendeesService(OnlineEventInvitationAccessor invitationAccessor, OnlineEventAttendeesModifier attendeesModifier, OnlineEventInvitationsModifier invitationsModifier, UserAccessor userAccessor, OnlineEventAccessor onlineEventAccessor)
        {
            this.invitationAccessor = invitationAccessor;
            this.attendeesModifier = attendeesModifier;
            this.invitationsModifier = invitationsModifier;
            this.userAccessor = userAccessor;
            this.eventAccessor = onlineEventAccessor;
        }
        public async Task<OnlineEvent> TryAttendEventAsync(EventSignUpRequest signUp, int userID)
        {
            await userAccessor.FindEntity(userID);
            if (userAccessor.User == null)
                return null;
            await eventAccessor.FindEntityWithAllDetailedAssocs(signUp.EventID);
            if (eventAccessor.Event == null || eventAccessor.Event.SpotsLeft < 1)
                return null;
            var invitation = eventAccessor.Event.InvitedUsers.FirstOrDefault(x => x.InvitedUser.ID == userID);
            if (invitation != null)
            {
                await invitationAccessor.FindEntityWithDetailedAssocs(invitation.ID);
                invitationsModifier.RemoveInvitation(invitation);
            }
            if (!eventAccessor.Event.Users.Any(x => x.ID == userID))
                await attendeesModifier.AddAttendee(eventAccessor.Event, userAccessor.User, true);
            return eventAccessor.Event;
        }
        public async Task<string> TryHandleInvitationAsync(ContactInvitationResponseRequest responseRequest, int userID)
        {
            await invitationAccessor.FindEntityWithBasicAssocs(responseRequest.InvitationID);
            if (invitationAccessor.EventInvitation == null || invitationAccessor.EventInvitation.Event == null || invitationAccessor.EventInvitation.InvitedUser == null || invitationAccessor.EventInvitation.InvitedUser.ID != userID)
                return "Error while searching for invitation";
            if (responseRequest.Response && !invitationAccessor.EventInvitation.Event.Users.Any(x => x.ID == invitationAccessor.EventInvitation.InvitedUser.ID))
            {
                if (invitationAccessor.EventInvitation.Event == null || invitationAccessor.EventInvitation.Event.SpotsLeft <= 0)
                    return "not possible";
                else
                    await attendeesModifier.AddAttendee(invitationAccessor.EventInvitation.Event, invitationAccessor.EventInvitation.InvitedUser, true);
            }
            invitationsModifier.RemoveInvitation(invitationAccessor.EventInvitation);
            return "ok";
        }
        public async Task<string> TryCreateInvitationAsync(EventInvitationRequest invitationRequest, int userID)
        {
            await userAccessor.FindEntity(userID);
            var author = userAccessor.User;
            if (author == null)
                return "author not found";
            await userAccessor.FindEntity(invitationRequest.InvitedUserID);
            var invitedUser = userAccessor.User;
            if (invitedUser == null)
                return "user not found";
            await eventAccessor.FindEntity(invitationRequest.EventID);
            invitationsModifier.CreateInvitation(eventAccessor.Event, invitedUser, userID);
            return "ok";
        }
    }
}
