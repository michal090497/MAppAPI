using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MApp.DataAccess.Models.Users;

public class ContactInvitation : IEntityBase
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    public int InvitationAuthorID { get; set; }
    public User InvitedUser { get; set; }
}
