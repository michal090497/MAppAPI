using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MApp.DataAccess.Models.Users;

namespace MAppAPI.Conversations
{
    public class ConversationMessage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int messageID { get; set; }
        [Required]
        public User sender { get; set; }
        public DateTime serverReceptionTimeGMT { get; set; }
        public string messageContent { get; set; }
        public ConversationMessage() 
        {

        }
    }
}
