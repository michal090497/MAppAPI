using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MApp.Common.Extensions;
using MAppAPI.Models.Responses.OnlineEvents;
using MApp.DataAccess.DataAccessors.UsersAccessors;

namespace MAppAPI.Controllers.OnlineEventsControllers
{
    [ApiController]
    [Route("[controller]")]
    public class OnlineEventInvitationsController : ControllerBase
    {
        private readonly ILogger<OnlineEventInvitationsController> _logger;
        UserWithOnlineEventsInvitationsAccessor userAccessor;
        public OnlineEventInvitationsController(ILogger<OnlineEventInvitationsController> logger, UserWithOnlineEventsInvitationsAccessor userAccessor)
        {
            _logger = logger;
            this.userAccessor = userAccessor;
        }
        [Authorize]
        [HttpGet]
        public async Task<List<OnlineEventInvitationForSending>> ReturnInvitationList()
        {
            var userID = Request.GetUserID();
            if (userID < 1)
                return new List<OnlineEventInvitationForSending>();
            await userAccessor.FindEntityWithDetailedAssocs(userID);
            if (userAccessor.User == null)
                return new List<OnlineEventInvitationForSending>();
            var listForSending = await OnlineEventInvitationForSending.CreateList(userAccessor.User.OnlineEventsInvitations);
            return listForSending;
        }
    }
}
