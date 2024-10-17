using MApp.DataAccess.Models.OnlineEvents;
using MApp.DataAccess.Models.Users;
using MAppAPI.Models.Responses.EventsBase;
using MAppAPI.Models.Responses.Users;

namespace MAppAPI.Models.Responses.OnlineEvents;

public class OnlineEventForSending : IEventForSendingBase<OnlineEvent, OnlineEventForSending, OnlineEventCategory>
{
    public DateTime? EventDate { set; get; }

    public string EventTitle { set; get; }

    public string EventDescription { set; get; }
    public int SpotsLeft { get; set; }

    public int ID { get; set; }
    public List<SimplifiedUser> SimplifiedUsers { get; set; }
    public bool IsUsersListPublic { get; set; }
    public OnlineEventCategory Category { get; set; }
    public string? Subcategory { get; set; }
    public int CreatorID { get; set; }

    public OnlineEventForSending(OnlineEvent onlineEvent, int util)
    {
        ID = onlineEvent.ID;
        EventDate = onlineEvent.EventDate;
        EventTitle = onlineEvent.EventTitle;
        EventDescription = onlineEvent.EventDescription;
        SimplifiedUsers = new List<SimplifiedUser>();
        SpotsLeft = onlineEvent.SpotsLeft;
        IsUsersListPublic = onlineEvent.IsUsersListPublic;
        Category = onlineEvent.Category;
        Subcategory = onlineEvent.Subcategory;
        CreatorID = onlineEvent.CreatorID;
    }

    protected OnlineEventForSending(OnlineEvent onlineEvent)
    {
        ID = onlineEvent.ID;
        EventDate = onlineEvent.EventDate;
        EventTitle = onlineEvent.EventTitle;
        EventDescription = onlineEvent.EventDescription;
        SimplifiedUsers = new List<SimplifiedUser>();
        SpotsLeft = onlineEvent.SpotsLeft;
        IsUsersListPublic = onlineEvent.IsUsersListPublic;
        Category = onlineEvent.Category;
        Subcategory = onlineEvent.Subcategory;
        CreatorID = onlineEvent.CreatorID;
        //ConvertUsersForSending(onlineEvent.users.ToList());
    }
    public static async Task<OnlineEventForSending> Create(OnlineEvent tempEvent)
    {
        var eventForSending = new OnlineEventForSending(tempEvent);
        await eventForSending.ConvertUsersForSending(tempEvent.Users.ToList());
        return eventForSending;
    }

    public static async Task<List<OnlineEventForSending>> CreateList(List<OnlineEvent> onlineEvents)
    {
        var onlineEventForSending = new List<OnlineEventForSending>();
        foreach (OnlineEvent onlineEvent in onlineEvents)
        {
            var tempEvent = await Create(onlineEvent);
            onlineEventForSending.Add(tempEvent);
        }
        return onlineEventForSending;
    }

    public static List<OnlineEventForSending> CreateList(List<OnlineEvent> tempEvents, int util)
    {
        var onlineEventForSending = new List<OnlineEventForSending>();
        foreach (OnlineEvent onlineEvent in tempEvents)
        {
            var tempEvent = new OnlineEventForSending(onlineEvent, util);
            onlineEventForSending.Add(tempEvent);
        }
        return onlineEventForSending;
    }
    protected async Task ConvertUsersForSending(List<User> users)
    {
        SimplifiedUsers = await SimplifiedUser.CreateFromICollection(users);
    }
}
