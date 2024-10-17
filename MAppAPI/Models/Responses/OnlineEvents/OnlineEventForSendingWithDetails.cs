using MApp.DataAccess.Models.OnlineEvents;
using MAppAPI.Models.Responses.EventsBase;
using MAppAPI.Models.Responses.EventsStatuses;

namespace MAppAPI.Models.Responses.OnlineEvents;

public class OnlineEventForSendingWithDetails : OnlineEventForSending, IEventForSendingWithDetailsBase<OnlineEvent, OnlineEventForSendingWithDetails, OnlineEventCategory, OnlineEventDetails>
{
    public OnlineEventDetails Details { get; set; }
    public List<EventsStatusForSending> Statuses { get; set; }
    public OnlineEventForSendingWithDetails(OnlineEvent onlineEvent, int util) : base(onlineEvent, util)
    {
        Details = null;
        Statuses = new List<EventsStatusForSending>();
    }
    private OnlineEventForSendingWithDetails(OnlineEvent onlineEvent) : base(onlineEvent)
    {
        Details = onlineEvent.Details;
    }
    public static async Task<OnlineEventForSendingWithDetails> CreateWithDetails(OnlineEvent onlineEvent)
    {
        var eventForSending = new OnlineEventForSendingWithDetails(onlineEvent);
        await eventForSending.ConvertUsersForSending(onlineEvent.Users.ToList());
        eventForSending.Statuses = await EventsStatusForSending.ConvertList(onlineEvent.Statuses);
        return eventForSending;
    }

    public static async Task<List<OnlineEventForSendingWithDetails>> CreateListWithDetails(List<OnlineEvent> onlineEvents)
    {
        var onlineEventForSendingWithDetails = new List<OnlineEventForSendingWithDetails>();
        foreach (OnlineEvent onlineEvent in onlineEvents)
        {
            var tempEvent = await CreateWithDetails(onlineEvent);
            onlineEventForSendingWithDetails.Add(tempEvent);
        }
        return onlineEventForSendingWithDetails;
    }

    public static List<OnlineEventForSendingWithDetails> CreateListWithDetails(List<OnlineEvent> onlineEvents, int util)
    {
        var onlineEventForSendingWithDetails = new List<OnlineEventForSendingWithDetails>();
        foreach (OnlineEvent onlineEvent in onlineEvents)
        {
            var tempEvent = new OnlineEventForSendingWithDetails(onlineEvent, util);
            onlineEventForSendingWithDetails.Add(tempEvent);
        }
        return onlineEventForSendingWithDetails;
    }
}
