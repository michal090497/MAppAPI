using MApp.DataAccess.Models.Users;

namespace MAppAPI.Models.Requests.EventsBase
{
    public interface IEventRequest
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
    }
}
