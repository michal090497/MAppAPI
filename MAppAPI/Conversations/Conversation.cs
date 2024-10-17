using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MApp.DataAccess.Models.Users;

namespace MAppAPI.Conversations
{
    public class Conversation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int conversationID { get; set; }
        public DateTime creationTimeGMT { get; set; }
        public DateTime lastEditionTimeGMT { get; set; }
        public virtual ICollection<User> users { get; set; }
        public virtual ICollection<ConversationMessage> messages { get; set; }
        public Conversation()
        {
            messages = new HashSet<ConversationMessage>();
            users = new HashSet<User>();
        }

    }
}
