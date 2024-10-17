using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MApp.DataAccess.Models.EventsStatuses;
using MApp.DataAccess.Models.Users;
using MApp.DataAccess.Models.EventsBase;

namespace MApp.DataAccess.Models.PhysicalEvents;

public class PhysicalEvent : IEventBase
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    public DateTime? EventDate { get; set; }
    public DateTime? EventDateGMT { get; set; }
    public string EventTitle { get; set; }
    public string EventDescription { get; set; }
    public double Longtitude { get; set; }
    public double Latitude { get; set; }
    public int SpotsLeft { get; set; }
    public int Spots { get; set; }
    public bool IsUsersListPublic { get; set; }
    public bool ShowAfterAllSpotsTaken { get; set; }
    public bool IsEventPrivate { get; set; }
    public bool EventForFriendsOnly { get; set; }
    public PhysicalEventCategory Category { get; set; }
    public string? Subcategory { get; set; }
    public PhysicalEventDetails Details { get; set; }
    public int CreatorID { get; set; }
    public virtual ICollection<User> Users { get; set; }
    public virtual ICollection<PhysicalEventAttendee> Attendees { get; set; }
    public virtual ICollection<PhysicalEventInvitation> InvitedUsers { get; set; }
    public virtual ICollection<EventStatus> Statuses { get; set; }
    public PhysicalEvent()
    {
        Users = new HashSet<User>();
        Attendees = new HashSet<PhysicalEventAttendee>();
        Statuses = new HashSet<EventStatus>();
        InvitedUsers = new HashSet<PhysicalEventInvitation>();
        Category = new PhysicalEventCategory();
        Details = new PhysicalEventDetails();
    }
}
