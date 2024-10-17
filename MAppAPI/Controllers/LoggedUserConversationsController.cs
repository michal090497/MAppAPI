using Microsoft.AspNetCore.Mvc;

namespace MAppAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoggedUserConversationsController : ControllerBase
    {
        public LoggedUserConversationsController() { }
        /*private readonly ILogger<LoggedUserConversationsController> _logger;
        DatabaseConnectionProvider database;

        public LoggedUserConversationsController(ILogger<LoggedUserConversationsController> logger, DatabaseConnectionProvider databaseConnectionProvider)
        {
            _logger = logger;
            database = databaseConnectionProvider;
        }

        [Authorize]
        [HttpPost]
        public List<ConversationForSending> UsersConversations([FromBody] List<int> conversationsID)
        {
            var conversations = database.conversations.Include(x => x.messages).Include(x => x.users).Where(x => conversationsID.Contains(x.conversationID)).ToList();
            var conversationsForSending = ConversationForSending.ConvertList(conversations);
            return conversationsForSending;
        }*/
    }
}
