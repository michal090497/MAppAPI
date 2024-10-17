using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MApp.DataAccess.Models.Users;

namespace MApp.DataAccess.Models.EventsStatuses;

public class EventStatusComment : IEventsStatusesBase
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    [Required]
    public User Creator { get; set; }
    public DateTime CreationTimeGMT { get; set; }
    public string Content { get; set; }
    public virtual EventStatus Status { get; set; }
    public EventStatusComment()
    {

    }
}
