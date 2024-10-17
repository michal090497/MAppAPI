using MApp.DataAccess.Models.PhysicalEvents;
using MAppAPI.Models.Requests.EventsBase;

namespace MAppAPI.Models.Requests.PhysicalEvents;

public class PhysicalEventsFilterRequest : IEventsFilterRequest<PhysicalEventCategory>
{
    public bool IsDefaultRequest { get; set; }
    public DateTime EventDateFrom { get; set; }
    public DateTime EventDateTo { get; set; }
    public int SpotsLeftMin { get; set; }
    public int SpotsMax { get; set; }
    public List<PhysicalEventCategory> Categories { get; set; }
    public string Subcategory { get; set; }
    public bool IsUsersListPublic { get; set; }
    public double LongtitudeMin { get; set; }
    public double LongtitudeMax { get; set; }
    public double LatitudeMin { get; set; }
    public double LatitudeMax { get; set; }
    public PhysicalEventsFilterRequest()
    {
        Categories = new List<PhysicalEventCategory>();
    }
}
