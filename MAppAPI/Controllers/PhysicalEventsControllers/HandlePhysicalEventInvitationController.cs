using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MApp.Common.Extensions;
using MAppAPI.Models.Requests.Users;
using MAppAPI.ControllersServices.PhysicalEventsServices;

namespace MAppAPI.Controllers.PhysicalEventsControllers
{
    [ApiController]
    [Route("[controller]")]
    public class HandlePhysicalEventInvitationController : ControllerBase
    {
        private readonly ILogger<HandlePhysicalEventInvitationController> _logger;
        PhysicalEventAttendeesService attendeesService;
        public HandlePhysicalEventInvitationController(ILogger<HandlePhysicalEventInvitationController> logger, PhysicalEventAttendeesService attendeesService)
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
