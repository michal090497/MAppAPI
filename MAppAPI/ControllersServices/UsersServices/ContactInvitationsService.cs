using MApp.DataAccess.DataAccessors.ContactInvitationsAccessors;
using MApp.DataAccess.DataAccessors.UsersAccessors;
using MApp.DataAccess.DataModifiers.UsersModifiers;
using MApp.DataAccess.Models.Users;
using MAppAPI.Models.Requests.Users;

namespace MAppAPI.ControllersServices.UsersServices
{
    public class ContactInvitationsService
    {
        UserAccessor userAccessor;
        UserWithContactInvitationsAccessor receiverUserAccessor;
        ContactInvitationAccessor invitationAccessor;
        ContactInvitationsModifier invitationsModifier;
        public ContactInvitationsService(ContactInvitationAccessor invitationAccessor, UserAccessor userAccessor, ContactInvitationsModifier invitationsModifier, UserWithContactInvitationsAccessor receiverUserAccessor)
        {
            this.invitationAccessor = invitationAccessor;
            this.userAccessor = userAccessor;
            this.invitationsModifier = invitationsModifier;
            this.receiverUserAccessor = receiverUserAccessor;
        }
        public async Task<string> TryCreateInvitationAsync(int receiverID, int userID)
        {
            await userAccessor.FindEntity(userID);
            if (userAccessor.User == null)
                return "author invitation not found";
            await receiverUserAccessor.FindEntity(receiverID);
            if (receiverUserAccessor.User == null)
                return "user not found";
            if (!receiverUserAccessor.User.Invitations.Any(x => x.InvitationAuthorID == userID))
                await invitationsModifier.CreateInvitation(userID, receiverUserAccessor.User);
            return "ok";
        }
        public async Task<string> TryHandleInvitationAsync(ContactInvitationResponseRequest responseRequest, int userID)
        {
            await invitationAccessor.FindEntityWithBasicAssocs(responseRequest.InvitationID);
            if (invitationAccessor.ContactInvitation == null || invitationAccessor.ContactInvitation.InvitedUser == null || invitationAccessor.ContactInvitation.InvitedUser.ID != userID)
                return "Error while searching for invitation";
            await userAccessor.FindEntity(invitationAccessor.ContactInvitation.InvitationAuthorID);
            if (userAccessor.User == null)
                return "invitationAuthor not found";
            if (responseRequest.Response)
                await invitationsModifier.AddContactAndRemoveContactInvitation(invitationAccessor.ContactInvitation.InvitedUser, userAccessor.User, invitationAccessor.ContactInvitation);
            else
                await invitationsModifier.RemoveContactInvitation(invitationAccessor.ContactInvitation.InvitedUser, invitationAccessor.ContactInvitation);
            return "ok";
        }
    }
}
