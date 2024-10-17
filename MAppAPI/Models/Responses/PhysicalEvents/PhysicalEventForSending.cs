using MApp.DataAccess.Models.PhysicalEvents;
using MApp.DataAccess.Models.Users;
using MAppAPI.Models.Responses.EventsBase;
using MAppAPI.Models.Responses.Users;

namespace MAppAPI.Models.Responses.PhysicalEvents;

public class PhysicalEventForSending : IEventForSendingBase<PhysicalEvent, PhysicalEventForSending, PhysicalEventCategory>
{
    public DateTime? EventDate { set; get; }

    public string EventTitle { set; get; }

    public string EventDescription { set; get; }
    public int SpotsLeft { get; set; }

    public int ID { get; set; }
    public List<SimplifiedUser> SimplifiedUsers { get; set; }
    public bool IsUsersListPublic { get; set; }
    public PhysicalEventCategory Category { get; set; }
    public string? Subcategory { get; set; }
    public int CreatorID { get; set; }
    public double Longtitude { get; set; }
    public double Latitude { get; set; }

    public PhysicalEventForSending(PhysicalEvent physicalEvent, int util)
    {
        ID = physicalEvent.ID;
        EventDate = physicalEvent.EventDate;
        EventTitle = physicalEvent.EventTitle;
        EventDescription = physicalEvent.EventDescription;
        Latitude = physicalEvent.Latitude;
        Longtitude = physicalEvent.Longtitude;
        SimplifiedUsers = new List<SimplifiedUser>();
        SpotsLeft = physicalEvent.SpotsLeft;
        IsUsersListPublic = physicalEvent.IsUsersListPublic;
        Category = physicalEvent.Category;
        CreatorID = physicalEvent.CreatorID;
        Subcategory = physicalEvent.Subcategory;
    }

    protected PhysicalEventForSending(PhysicalEvent physicalEvent)
    {
        ID = physicalEvent.ID;
        EventDate = physicalEvent.EventDate;
        EventTitle = physicalEvent.EventTitle;
        EventDescription = physicalEvent.EventDescription;
        Latitude = physicalEvent.Latitude;
        Longtitude = physicalEvent.Longtitude;
        SimplifiedUsers = new List<SimplifiedUser>();
        SpotsLeft = physicalEvent.SpotsLeft;
        IsUsersListPublic = physicalEvent.IsUsersListPublic;
        Category = physicalEvent.Category;
        CreatorID = physicalEvent.CreatorID;
        Subcategory = physicalEvent.Subcategory;
    }
    public static async Task<PhysicalEventForSending> Create(PhysicalEvent tempEvent)
    {
        var eventForSending = new PhysicalEventForSending(tempEvent);
        await eventForSending.ConvertUsersForSending(tempEvent.Users.ToList());
        return eventForSending;
    }

    public static async Task<List<PhysicalEventForSending>> CreateList(List<PhysicalEvent> physicalEvents)
    {
        var physicalEventsForSending = new List<PhysicalEventForSending>();
        foreach (PhysicalEvent physicalEvent in physicalEvents)
        {
            var tempEvent = await Create(physicalEvent);
            physicalEventsForSending.Add(tempEvent);
        }
        return physicalEventsForSending;
    }

    public static List<PhysicalEventForSending> CreateList(List<PhysicalEvent> tempEvents, int util)
    {
        var physicalEventsForSending = new List<PhysicalEventForSending>();
        foreach (PhysicalEvent physicalEvent in tempEvents)
        {
            var tempEvent = new PhysicalEventForSending(physicalEvent, util);
            physicalEventsForSending.Add(tempEvent);
        }
        return physicalEventsForSending;
    }

    protected async Task ConvertUsersForSending(List<User> users)
    {
        SimplifiedUsers = await SimplifiedUser.CreateFromICollection(users);
    }
}
