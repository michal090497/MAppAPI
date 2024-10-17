using MApp.Common.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MAppAPI.Models.Responses.PhysicalEvents;
using MAppAPI.ControllersServices.PhysicalEventsServices;
using MAppAPI.Models.Requests;

namespace MAppAPI.Controllers.PhysicalEventsControllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhysicalEventAttendeesController : ControllerBase
    {
        private readonly ILogger<PhysicalEventAttendeesController> _logger;
        PhysicalEventAttendeesService attendeesService;

        public PhysicalEventAttendeesController(ILogger<PhysicalEventAttendeesController> logger, PhysicalEventAttendeesService attendeesService)
        {
            _logger = logger;
            this.attendeesService = attendeesService;
        }

        [Authorize]
        [HttpPost]
        public async Task<PhysicalEventForSendingWithDetails> AttendPhysicalEvent([FromBody] EventSignUpRequest signUp)
        {
            var userID = Request.GetUserID();
            if (userID < 1)
                return null;
            var tempEvent = await attendeesService.TryAttendEventAsync(signUp, userID);
            if (tempEvent == null)
                return null;
            return await PhysicalEventForSendingWithDetails.CreateWithDetails(tempEvent);
        }
    }
}
