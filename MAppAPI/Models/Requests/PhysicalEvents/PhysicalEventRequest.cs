using MApp.DataAccess.Models.Users;
using MAppAPI.Models.Requests.EventsBase;

namespace MAppAPI.Models.Requests.PhysicalEvents;

public class PhysicalEventRequest : IEventRequest
{
    public DateTime EventDate { get; set; }
    public string EventTitle { get; set; }
    public string EventDescription { get; set; }
    public int SpotsLeft { get; set; }
    public List<User> Users { get; set; }
    public bool IsUsersListPublic { get; set; }
    public bool IsEventPrivate { get; set; }
    public int CategoryID { get; set; }
    public string? Subcategory { get; set; }
    public string Details { get; set; }
    public string WayOfContact { get; set; }
    public string ContactDetails { get; set; }
    public double Longtitude { get; set; }
    public double Latitude { get; set; }
    public string HowToGetThereInfo { get; set; } = string.Empty;
    public PhysicalEventRequest()
    {
        Users = new List<User>();
    }
}
