using MApp.DataAccess.Models.PhysicalEvents;
using MAppAPI.Models.Responses.EventsBase;
using MAppAPI.Models.Responses.EventsStatuses;

namespace MAppAPI.Models.Responses.PhysicalEvents;

public class PhysicalEventForSendingWithDetails : PhysicalEventForSending, IEventForSendingWithDetailsBase<PhysicalEvent, PhysicalEventForSendingWithDetails, PhysicalEventCategory, PhysicalEventDetails>
{
    public PhysicalEventDetails Details { get; set; }
    public List<EventsStatusForSending> Statuses { get; set; }
    public PhysicalEventForSendingWithDetails(PhysicalEvent physicalEvent, int util) : base(physicalEvent, util)
    {
        Details = null;
        Statuses = new List<EventsStatusForSending>();
    }
    private PhysicalEventForSendingWithDetails(PhysicalEvent physicalEvent) : base(physicalEvent)
    {
        Details = physicalEvent.Details;
    }
    public static async Task<PhysicalEventForSendingWithDetails> CreateWithDetails(PhysicalEvent physicalEvent)
    {
        var eventForSending = new PhysicalEventForSendingWithDetails(physicalEvent);
        await eventForSending.ConvertUsersForSending(physicalEvent.Users.ToList());
        eventForSending.Statuses = await EventsStatusForSending.ConvertList(physicalEvent.Statuses);
        return eventForSending;
    }

    public static async Task<List<PhysicalEventForSendingWithDetails>> CreateListWithDetails(List<PhysicalEvent> physicalEvents)
    {
        var physicalEventsForSendingWithDetails = new List<PhysicalEventForSendingWithDetails>();
        foreach (PhysicalEvent physicalEvent in physicalEvents)
        {
            var tempEvent = await CreateWithDetails(physicalEvent);
            physicalEventsForSendingWithDetails.Add(tempEvent);
        }
        return physicalEventsForSendingWithDetails;
    }

    public static List<PhysicalEventForSendingWithDetails> CreateListWithDetails(List<PhysicalEvent> physicalEvents, int util)
    {
        var physicalEventsForSendingWithDetails = new List<PhysicalEventForSendingWithDetails>();
        foreach (PhysicalEvent physicalEvent in physicalEvents)
        {
            var tempEvent = new PhysicalEventForSendingWithDetails(physicalEvent, util);
            physicalEventsForSendingWithDetails.Add(tempEvent);
        }
        return physicalEventsForSendingWithDetails;
    }
}
