using Microsoft.AspNetCore.Mvc;

namespace MAppAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewMessageController : ControllerBase
    {
        public NewMessageController() { }
        /*private readonly ILogger<NewMessageController> _logger;
        DatabaseConnectionProvider database;

        public NewMessageController(ILogger<NewMessageController> logger, DatabaseConnectionProvider databaseConnectionProvider)
        {
            _logger = logger;
            database = databaseConnectionProvider;
        }

        [Authorize]
        [HttpPost]
        public ConversationForSending AddNewMessage([FromBody] AddConversationMessageRequest request)
        {
            var conversation = database.conversations.Include(x => x.messages).Where(x => x.conversationID == request.conversationID).FirstOrDefault();
            var user = database.allUsers.Where(x => x.userID == request.senderID).FirstOrDefault();
            var message = new ConversationMessage
            {
                sender = user,
                serverReceptionTimeGMT = DateTime.UtcNow,
                messageContent = request.messageContent
            };
            conversation.messages.Add(message);
            conversation.lastEditionTimeGMT = DateTime.UtcNow;
            database.SaveChanges();
            return new ConversationForSending(conversation);
        }*/
    }
}
