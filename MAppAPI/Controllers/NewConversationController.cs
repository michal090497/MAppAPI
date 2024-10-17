using Microsoft.AspNetCore.Mvc;

namespace MAppAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewConversationController : ControllerBase
    {
        public NewConversationController() { }
        /*private readonly ILogger<NewConversationController> _logger;
        DatabaseConnectionProvider database;

        public NewConversationController(ILogger<NewConversationController> logger, DatabaseConnectionProvider databaseConnectionProvider)
        {
            _logger = logger;
            database = databaseConnectionProvider;
        }

        [Authorize]
        [HttpPost]
        public ConversationForSending CreateConversation([FromBody] List<int> usersIDs)
        {
            var tempUsers = database.allUsers.Where(x => usersIDs.Contains(x.userID)).ToHashSet();
            var conversation = new Conversation
            {
                creationTimeGMT = DateTime.UtcNow,
                lastEditionTimeGMT = DateTime.UtcNow,
                users = tempUsers
            };
            database.conversations.Add(conversation);
            database.SaveChanges();
            return new ConversationForSending(conversation);
        }*/
    }
}
