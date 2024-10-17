using MAppAPI.Models.Responses.Users;

namespace MAppAPI.Conversations
{
    public class ConversationMessageForSending
    {
        public int messageID { get; set; }
        public SimplifiedUser sender { get; set; }
        public DateTime serverReceptionTimeGMT { get; set; }
        public string messageContent { get; set; }
        public ConversationMessageForSending(ConversationMessage message)
        {
            messageID = message.messageID;
            //sender = SimplifiedUser.CreateFromUser(message.sender);
            serverReceptionTimeGMT = message.serverReceptionTimeGMT;
            messageContent = message.messageContent;
        }
    }
}
