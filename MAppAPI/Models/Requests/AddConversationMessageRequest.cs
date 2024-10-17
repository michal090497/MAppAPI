namespace MAppAPI.Models.Requests;

public class AddConversationMessageRequest
{
    public int conversationID { get; set; }
    public string messageContent { get; set; }
    public int senderID { get; set; }
    public AddConversationMessageRequest()
    {

    }
}
