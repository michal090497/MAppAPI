using Microsoft.AspNetCore.Mvc;

namespace MAppAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UpdateSingleConversationController : ControllerBase
    {
        public UpdateSingleConversationController() { }
        /*private readonly ILogger<UpdateSingleConversationController> _logger;
        DatabaseConnectionProvider database;

        public UpdateSingleConversationController(ILogger<UpdateSingleConversationController> logger, DatabaseConnectionProvider databaseConnectionProvider)
        {
            _logger = logger;
            database = databaseConnectionProvider;
        }

        [Authorize]
        [HttpPost]
        public ConversationForSending UpdateConversation([FromBody] UpdateConversationRequest request)
        {
            var conversation = database.conversations.Include(x => x.messages).Where(x => x.conversationID == request.conversationID).FirstOrDefault();
            var message = conversation.messages.OrderByDescending(x => x.serverReceptionTimeGMT).FirstOrDefault();
            //var temp = conversation.messages.OrderByDescending(x => x.serverReceptionTimeGMT).FirstOrDefault().sender.userID != request.userID;
            if (message.sender.userID != request.userID && message.serverReceptionTimeGMT == conversation.lastEditionTimeGMT)
            {
                conversation.lastEditionTimeGMT = DateTime.UtcNow;
                database.SaveChanges();
            }
            return new ConversationForSending(conversation);
        }*/
    }
}
