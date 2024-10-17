using MApp.DataAccess.Models.EventsBase;
using MAppAPI.Models.Responses.EventsStatuses;

namespace MAppAPI.Models.Responses.EventsBase
{
    public interface IEventForSendingWithDetailsBase<EventType, EventForSendingType, EventCategory, EventDetails> : IEventForSendingBase<EventType, EventForSendingType, EventCategory>
        where EventType : IEventBase 
        where EventForSendingType : IEventForSendingBase<EventType, EventForSendingType, EventCategory> 
        where EventCategory : IEventCategoryBase 
        where EventDetails : IEventDetailsBase
    {
        public EventDetails Details { get; set; }
        public List<EventsStatusForSending> Statuses { get; set; }
        public static Task<EventForSendingType?> CreateWithDetails(EventType tempEvent) { return null; }

        public static async Task<List<EventForSendingType>> CreateListWithDetails(List<EventType> tempEvents) { return null; }

        public static List<EventForSendingType> CreateListWithDetails(List<EventType> tempEvents, int util) { return null; }
    }
}
