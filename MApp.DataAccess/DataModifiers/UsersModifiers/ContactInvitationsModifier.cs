using MApp.DataAccess.Context;
using MApp.DataAccess.Models.Users;

namespace MApp.DataAccess.DataModifiers.UsersModifiers
{
    public class ContactInvitationsModifier : DataModifierBase
    {
        public ContactInvitationsModifier(MAppDbContext dbContext) : base(dbContext) { }
        public async Task CreateInvitation(int authorID, User receiver)
        {
            var invitation = new ContactInvitation { InvitationAuthorID = authorID };
            receiver.Invitations.Add(invitation);
            await dbContext.SaveChangesAsync();
        }
        public async Task AddContactAndRemoveContactInvitation(User user, User invitationAuthor, ContactInvitation invitation)
        {
            invitationAuthor.Contacts.Add(user);
            user.Contacts.Add(invitationAuthor);
            await RemoveContactInvitation(user, invitation);
        }
        public async Task RemoveContactInvitation(User user, ContactInvitation invitation)
        {
            user.Invitations.Remove(invitation);
            dbContext.ContactInvitations.Remove(invitation);
            await dbContext.SaveChangesAsync();
        }
    }
}
