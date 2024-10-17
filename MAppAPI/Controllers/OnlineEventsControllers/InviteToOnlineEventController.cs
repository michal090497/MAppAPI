using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MApp.Common.Extensions;
using MAppAPI.Models.Requests;
using MAppAPI.ControllersServices.OnlineEventsServices;

namespace MAppAPI.Controllers.OnlineEventsControllers
{
    [ApiController]
    [Route("[controller]")]
    public class InviteToOnlineEventController : ControllerBase
    {
        private readonly ILogger<InviteToOnlineEventController> _logger;
        OnlineEventAttendeesService attendeesService;
        public InviteToOnlineEventController(ILogger<InviteToOnlineEventController> logger, OnlineEventAttendeesService attendeesService)
        {
            _logger = logger;
            this.attendeesService = attendeesService;
        }
        [Authorize]
        [HttpPost]
        public async Task<string> SendInvitation([FromBody] EventInvitationRequest invitationRequest)
        {
            var userID = Request.GetUserID();
            if (userID < 1)
                return null;
            return await attendeesService.TryCreateInvitationAsync(invitationRequest, userID);
        }
    }
}
