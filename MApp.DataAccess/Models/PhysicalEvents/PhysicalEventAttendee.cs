using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MApp.DataAccess.Models.Users;
using MApp.DataAccess.Models.EventsBase;

namespace MApp.DataAccess.Models.PhysicalEvents;

public class PhysicalEventAttendee : IEventAttendeeBase<PhysicalEvent>
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    public DateTime? UpdateTime { get; set; }
    public bool IsAttending { get; set; }
    public virtual User User { get; set; }
    public virtual PhysicalEvent Event { get; set; }
}
