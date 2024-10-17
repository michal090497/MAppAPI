using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MApp.Common.Extensions;
using MAppAPI.Models.Requests.Users;
using MAppAPI.ControllersServices.OnlineEventsServices;

namespace MAppAPI.Controllers.OnlineEventsControllers
{
    [ApiController]
    [Route("[controller]")]
    public class HandleOnlineEventInvitationController : ControllerBase
    {
        private readonly ILogger<HandleOnlineEventInvitationController> _logger;
        OnlineEventAttendeesService attendeesService;
        public HandleOnlineEventInvitationController(ILogger<HandleOnlineEventInvitationController> logger, OnlineEventAttendeesService attendeesService)
        {
            _logger = logger;
            this.attendeesService = attendeesService;
        }
        [Authorize]
        [HttpPost]
        public async Task<string> HandleInvitation([FromBody] ContactInvitationResponseRequest responseRequest)
        {
            var userID = Request.GetUserID();
            if (userID < 1)
                return null;
            return await attendeesService.TryHandleInvitationAsync(responseRequest, userID);
        }
    }
}
