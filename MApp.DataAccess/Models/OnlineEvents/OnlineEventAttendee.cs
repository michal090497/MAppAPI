using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MApp.DataAccess.Models.Users;
using MApp.DataAccess.Models.EventsBase;

namespace MApp.DataAccess.Models.OnlineEvents;

public class OnlineEventAttendee : IEventAttendeeBase<OnlineEvent>
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    public DateTime? UpdateTime { get; set; }
    public bool IsAttending { get; set; }
    public virtual User User { get; set; }
    public OnlineEvent Event { get; set; }
}
