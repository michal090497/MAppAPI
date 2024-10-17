using MApp.DataAccess.Models.EventsStatuses;
using MApp.DataAccess.Models.Users;

namespace MApp.DataAccess.Models.EventsBase;

public interface IEventBase : IEntityBase
{
    DateTime? EventDate { get; }
    public DateTime? EventDateGMT { get; set; }
    string EventTitle { get; }
    string EventDescription { get; }
    public int SpotsLeft { get; set; }
    public int Spots { get; set; }
    public bool IsUsersListPublic { get; set; }
    public bool ShowAfterAllSpotsTaken { get; set; }
    public bool IsEventPrivate { get; set; }
    public bool EventForFriendsOnly { get; set; }
    public string? Subcategory { get; set; }
    public int CreatorID { get; set; }
    public ICollection<User> Users { get; set; }
    public ICollection<EventStatus> Statuses { get; set; }
}
