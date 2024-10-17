using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MApp.DataAccess.Models.Users;
using MApp.DataAccess.Models.EventsBase;

namespace MApp.DataAccess.Models.PhysicalEvents;

public class PhysicalEventCategory : IEventCategoryBase
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    public string CategoryName { get; set; }
    public virtual ICollection<User> FavouriteFor { get; set; }
    public string CategoryColor { get; set; }
    public PhysicalEventCategory()
    {
        FavouriteFor = new HashSet<User>();
    }

}
