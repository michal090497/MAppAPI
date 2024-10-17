using MApp.DataAccess.Models.OnlineEvents;
using MApp.DataAccess.Models.PhysicalEvents;

namespace MAppAPI.Models.Requests.Users;

public class ProfileDetailsRequest
{
    public string Bio { get; set; } = string.Empty;
    public string Languages { get; set; } = string.Empty;
    public string Hobbies { get; set; } = string.Empty;
    public List<OnlineEventCategory> FavouriteOnlineEventCategories { get; set; } = new List<OnlineEventCategory>();
    public List<PhysicalEventCategory> FavouritePhysicalEventCategories { get; set; } = new List<PhysicalEventCategory>();
    public string ProfilePicture { get; set; } = string.Empty;
}
