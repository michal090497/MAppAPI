using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MApp.DataAccess.Models.OnlineEvents;
using MApp.DataAccess.Models.PhysicalEvents;
using MApp.DataAccess.Models.Users;

namespace MApp.DataAccess.Models.EventsStatuses;

public class EventStatus : IEventsStatusesBase
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    [Required]
    public User Creator { get; set; }
    public DateTime CreationTimeGMT { get; set; }
    public string Content { get; set; }
    public virtual ICollection<EventStatusComment> Comments { get; set; }
    public virtual OnlineEvent? OnlineEvent { get; set; }
    public virtual PhysicalEvent? PhysicalEvent { get; set; }
    public EventStatus()
    {
        Comments = new HashSet<EventStatusComment>();
    }
}
