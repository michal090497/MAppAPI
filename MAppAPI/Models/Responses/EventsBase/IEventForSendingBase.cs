using MApp.DataAccess.Models.EventsBase;
using MAppAPI.Models.Responses.Users;

namespace MAppAPI.Models.Responses.EventsBase
{
    public interface IEventForSendingBase<EventType, EventForSendingType, EventCategory> 
        where EventType : IEventBase
        where EventForSendingType : IEventForSendingBase<EventType, EventForSendingType, EventCategory>
        where EventCategory : IEventCategoryBase
    {
        public DateTime? EventDate { set; get; }

        public string EventTitle { set; get; }

        public string EventDescription { set; get; }
        public int SpotsLeft { get; set; }

        public int ID { get; set; }
        public List<SimplifiedUser> SimplifiedUsers { get; set; }
        public bool IsUsersListPublic { get; set; }
        public EventCategory Category { get; set; }
        public string? Subcategory { get; set; }
        public int CreatorID { get; set; }
        public static Task<EventForSendingType?> Create(EventType tempEvent) { return null; }

        public static async Task<List<EventForSendingType>> CreateList(List<EventType> tempEvents) { return null; }

        public static List<EventForSendingType> CreateList(List<EventType> tempEvents, int util) { return null; }
    }
}
