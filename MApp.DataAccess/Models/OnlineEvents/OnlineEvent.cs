using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MApp.DataAccess.Models.EventsStatuses;
using MApp.DataAccess.Models.Users;
using MApp.DataAccess.Models.EventsBase;

namespace MApp.DataAccess.Models.OnlineEvents;

public class OnlineEvent : IEventBase
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    public DateTime? EventDate { get; set; }
    public DateTime? EventDateGMT { get; set; }
    public string EventTitle { get; set; }
    public string EventDescription { get; set; }
    public int SpotsLeft { get; set; }
    public int Spots { get; set; }
    public bool IsUsersListPublic { get; set; }
    public bool ShowAfterAllSpotsTaken { get; set; }
    public bool IsEventPrivate { get; set; }
    public bool EventForFriendsOnly { get; set; }
    public OnlineEventCategory Category { get; set; }
    public string? Subcategory { get; set; }
    public OnlineEventDetails Details { get; set; }
    public int CreatorID { get; set; }
    public virtual ICollection<User> Users { get; set; }
    public virtual ICollection<OnlineEventAttendee> Attendees { get; set; }
    public virtual ICollection<OnlineEventInvitation> InvitedUsers { get; set; }
    public virtual ICollection<EventStatus> Statuses { get; set; }
    public OnlineEvent()
    {
        Users = new HashSet<User>();
        Attendees = new HashSet<OnlineEventAttendee>();
        Statuses = new HashSet<EventStatus>();
        InvitedUsers = new HashSet<OnlineEventInvitation>();
        Category = new OnlineEventCategory();
        Details = new OnlineEventDetails();
    }
}
