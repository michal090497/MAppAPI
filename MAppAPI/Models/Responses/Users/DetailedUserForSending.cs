using MApp.Common.Helpers;
using MApp.DataAccess.Models.OnlineEvents;
using MApp.DataAccess.Models.PhysicalEvents;
using MApp.DataAccess.Models.Users;

namespace MAppAPI.Models.Responses.Users;

public class DetailedUserForSending : IExtendedUser
{
    public string Username { get; protected set; } = string.Empty;
    public int ID { get; protected set; } = -1;
    public string Bio { get; set; } = string.Empty;
    public string Languages { get; set; } = string.Empty;
    public string Hobbies { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; } = DateTime.MinValue;
    public string ProfilePicture { get; set; } = string.Empty;
    public int InvitationID { get; set; }
    public bool IsInvited { get; set; }
    public bool IsContact { get; set; }
    public List<SimplifiedUser> Contacts { get; set; } = new List<SimplifiedUser>();
    public List<OnlineEventCategory> FavouriteOnlineEventCategories { get; set; } = new List<OnlineEventCategory>();
    public List<PhysicalEventCategory> FavouritePhysicalEventCategories { get; set; } = new List<PhysicalEventCategory>();
    public DetailedUserForSending() { }
    protected DetailedUserForSending(User user)
    {
        Username = user.Username;
        ID = user.ID;
        Bio = user.Bio;
        Languages = user.Languages;
        Hobbies = user.Hobbies;
        DateOfBirth = user.DateOfBirth;
        FavouriteOnlineEventCategories = user.FavouriteOnlineEventCategories.ToList();
        FavouritePhysicalEventCategories = user.FavouritePhysicalEventCategories.ToList();
    }
    public static async Task<DetailedUserForSending> Create(User user, bool profilePictureNeeded, int invitationID, bool isInvited, bool isContact)
    {
        var userForSending = new DetailedUserForSending(user);
        userForSending.Contacts = await SimplifiedUser.CreateFromICollection(user.Contacts);
        userForSending.InvitationID = invitationID;
        userForSending.IsInvited = isInvited;
        userForSending.IsContact = isContact;
        if (profilePictureNeeded)
            userForSending.ProfilePicture = await PictureHelper.ConvertProfilePictureToString(user.ID);
        return userForSending;
    }
}
