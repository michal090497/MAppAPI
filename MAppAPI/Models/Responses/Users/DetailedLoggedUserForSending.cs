using MApp.Common.Helpers;
using MApp.DataAccess.Models.Users;

namespace MAppAPI.Models.Responses.Users;

public class DetailedLoggedUserForSending : DetailedUserForSending
{
    public List<ContactInvitation> Invitations { get; set; } = new List<ContactInvitation>();
    public DetailedLoggedUserForSending() { }
    private DetailedLoggedUserForSending(User user) : base(user) { }

    public static async Task<DetailedLoggedUserForSending> CreateWithDetails(User user, bool profilePictureNeeded)
    {
        var userForSending = new DetailedLoggedUserForSending(user);
        userForSending.InvitationID = -1;
        userForSending.IsInvited = false;
        userForSending.IsContact = false;
        userForSending.Contacts = await SimplifiedUser.CreateFromICollection(user.Contacts);
        if (profilePictureNeeded)
            userForSending.ProfilePicture = await PictureHelper.ConvertProfilePictureToString(user.ID);
        userForSending.Invitations = user.Invitations.ToList();
        return userForSending;
    }
}
