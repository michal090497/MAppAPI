using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MApp.Common.Extensions;
using MAppAPI.Models.Requests;
using MAppAPI.ControllersServices.PhysicalEventsServices;

namespace MAppAPI.Controllers.PhysicalEventsControllers
{
    [ApiController]
    [Route("[controller]")]
    public class InviteToPhysicalEventController : ControllerBase
    {
        private readonly ILogger<InviteToPhysicalEventController> _logger;
        PhysicalEventAttendeesService attendeesService;
        public InviteToPhysicalEventController(ILogger<InviteToPhysicalEventController> logger, PhysicalEventAttendeesService attendeesService)
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
