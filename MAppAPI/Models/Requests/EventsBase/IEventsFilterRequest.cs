using MApp.DataAccess.Models.EventsBase;

namespace MAppAPI.Models.Requests.EventsBase
{
    public interface IEventsFilterRequest<EventCategory>
        where EventCategory : IEventCategoryBase
    {
        public bool IsDefaultRequest { get; set; }
        public DateTime EventDateFrom { get; set; }
        public DateTime EventDateTo { get; set; }
        public int SpotsLeftMin { get; set; }
        public int SpotsMax { get; set; }
        public List<EventCategory> Categories { get; set; }
        public string Subcategory { get; set; }
        public bool IsUsersListPublic { get; set; }
    }
}
