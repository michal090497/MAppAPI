using MApp.DataAccess.Models.OnlineEvents;
using MApp.DataAccess.Models.PhysicalEvents;

namespace MAppAPI.Models.Responses.Users
{
    public interface IExtendedUser : IBasicUser
    {
        public string Bio { get; set; }
        public string Languages { get; set; }
        public string Hobbies { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ProfilePicture { get; set; }
        public int InvitationID { get; set; }
        public bool IsInvited { get; set; }
        public bool IsContact { get; set; }
        public List<SimplifiedUser> Contacts { get; set; }
        public List<OnlineEventCategory> FavouriteOnlineEventCategories { get; set; }
        public List<PhysicalEventCategory> FavouritePhysicalEventCategories { get; set; }
    }
}
