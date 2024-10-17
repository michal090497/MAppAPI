using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MApp.DataAccess.Models.Users;
using MApp.DataAccess.Models.EventsBase;

namespace MApp.DataAccess.Models.PhysicalEvents;

public class PhysicalEventInvitation : IEventInvitationBase<PhysicalEvent>
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    public User InvitedUser { get; set; }
    public int AuthorID { get; set; }
    public DateTime InvitationTime { get; set; }
    public PhysicalEvent Event { get; set; }
}
