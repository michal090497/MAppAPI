using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MApp.DataAccess.Models.Users;

namespace MApp.DataAccess.Models.PhysicalEvents;

public class PhysicalEventArchived// : IEventBase
{
    public DateTime? eventDate { get; set; }
    public DateTime? eventDateGMT { get; set; }
    public string eventTitle { get; set; }
    public string eventDescription { get; set; }
    public double longtitude { get; set; }
    public double latitude { get; set; }
    public int spotsLeft { get; set; }
    public string categoryName { get; set; }
    public string? subcategory { get; set; }
    public int creatorID { get; set; }
    public string users { get; set; }
    public int physicalEventsID { get; set; }
    public string details { get; set; }
    public string wayOfContact { get; set; }
    public string contactDetails { get; set; }
    public string howToGetThereInfo { get; set; }
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PhysicalEventsArchivedID { get; set; }
    public PhysicalEventArchived()
    {

    }

    public static string ConvertUsers(List<User> users)
    {
        var output = string.Empty;
        foreach (var user in users)
        {
            //output += user.userID.ToString() + ";";
        }
        return output;
    }
}
