using MAppAPI.Models.Responses.Users;

namespace MAppAPI.Conversations
{
    public class ConversationForSending
    {
        public int conversationID { get; set; }
        public DateTime lastEditionTimeGMT { get; set; }
        public virtual List<SimplifiedUser> users { get; set; }
        public virtual List<ConversationMessageForSending> messages { get; set; }
        public ConversationForSending(Conversation conversation)
        {
            conversationID = conversation.conversationID;
            lastEditionTimeGMT = conversation.lastEditionTimeGMT;
            users = new List<SimplifiedUser>();
            //foreach (var user in conversation.users)
            //   users.Add(SimplifiedUser.CreateFromUser(user));
            messages = new List<ConversationMessageForSending>();
            foreach (var message in conversation.messages)
                messages.Add(new ConversationMessageForSending(message));
        }
        public static List<ConversationForSending> ConvertList(List<Conversation> list)
        {
            var listForSending = new List<ConversationForSending>();
            foreach (var item in list)
                listForSending.Add(new ConversationForSending(item));
            return listForSending;
        }
    }
}
