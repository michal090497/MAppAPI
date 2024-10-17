using MApp.DataAccess.Models.OnlineEvents;
using MAppAPI.Models.Requests.EventsBase;

namespace MAppAPI.Models.Requests.OnlineEvents;

public class OnlineEventsFilterRequest : IEventsFilterRequest<OnlineEventCategory>
{
    public bool IsDefaultRequest { get; set; }
    public DateTime EventDateFrom { get; set; }
    public DateTime EventDateTo { get; set; }
    public int SpotsLeftMin { get; set; }
    public int SpotsMax { get; set; }
    public List<OnlineEventCategory> Categories { get; set; }
    public string Subcategory { get; set; }
    public bool IsUsersListPublic { get; set; }
    public OnlineEventsFilterRequest()
    {
        Categories = new List<OnlineEventCategory>();
    }
}
