using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MApp.DataAccess.Models.Users;

namespace MApp.DataAccess.Models.OnlineEvents;

public class OnlineEventArchived// : IEventBase
{
    public DateTime? eventDate { get; set; }
    //public DateTime? eventDateGMT { get; set; }
    public string eventTitle { get; set; }
    public string eventDescription { get; set; }
    public int spotsLeft { get; set; }
    public string categoryName { get; set; }
    public string? subcategory { get; set; }
    public int creatorID { get; set; }
    public string users { get; set; }
    public int onlineEventsID { get; set; }
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int onlineEventsArchivedID { get; set; }
    public string details { get; set; }
    public string wayOfContact { get; set; }
    public string contactDetails { get; set; }
    public OnlineEventArchived()
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
