using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MApp.DataAccess.Models.EventsBase;

namespace MApp.DataAccess.Models.PhysicalEvents;

public class PhysicalEventDetails : IEventDetailsBase
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    public string Details { get; set; }
    public string WayOfContact { get; set; }
    public string ContactDetails { get; set; }
    public string HowToGetThereInfo { get; set; }
}
