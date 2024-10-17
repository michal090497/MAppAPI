using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MApp.Common.Extensions;
using MAppAPI.Models.Responses.OnlineEvents;
using MAppAPI.ControllersServices.OnlineEventsServices;
using MAppAPI.Models.Requests;

namespace MAppAPI.Controllers.OnlineEventsControllers
{
    [ApiController]
    [Route("[controller]")]
    public class OnlineEventAttendeesController : ControllerBase
    {
        private readonly ILogger<OnlineEventAttendeesController> _logger;
        OnlineEventAttendeesService attendeesService;

        public OnlineEventAttendeesController(ILogger<OnlineEventAttendeesController> logger, OnlineEventAttendeesService attendeesService)
        {
            _logger = logger;
            this.attendeesService = attendeesService;
        }

        [Authorize]
        [HttpPost]
        public async Task<OnlineEventForSendingWithDetails> AttendOnlineEvent([FromBody] EventSignUpRequest signUp)
        {
            var userID = Request.GetUserID();
            if (userID < 1)
                return null;
            var tempEvent = await attendeesService.TryAttendEventAsync(signUp, userID);
            if (tempEvent == null)
                return null;
            return await OnlineEventForSendingWithDetails.CreateWithDetails(tempEvent);
        }
    }
}
