using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MApp.Common.Extensions;
using MAppAPI.Models.Responses.OnlineEvents;
using MApp.DataAccess.DataAccessors.UsersAccessors;

namespace MAppAPI.Controllers.OnlineEventsControllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssignedOnlineEventsController : ControllerBase
    {
        private readonly ILogger<AssignedOnlineEventsController> _logger;
        UserWithOnlineEventsAccessor onlineEventsAccessor;

        public AssignedOnlineEventsController(ILogger<AssignedOnlineEventsController> logger, UserWithOnlineEventsAccessor onlineEventsAccessor)
        {
            _logger = logger;
            this.onlineEventsAccessor = onlineEventsAccessor;
        }

        [Authorize]
        [HttpGet]
        public async Task<List<OnlineEventForSendingWithDetails>> GetListOfAttendedOnlineEvents()
        {
            var userID = Request.GetUserID();
            if (userID < 1)
                return new List<OnlineEventForSendingWithDetails>();
            await onlineEventsAccessor.FindEntity(userID);
            if (onlineEventsAccessor.User == null)
                return new List<OnlineEventForSendingWithDetails>();
            return OnlineEventForSendingWithDetails.CreateListWithDetails(onlineEventsAccessor.User.OnlineEvents.ToList(), 0);
        }
    }
}
