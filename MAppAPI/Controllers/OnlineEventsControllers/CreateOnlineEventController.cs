using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MApp.Common.Extensions;
using MAppAPI.Models.Requests.OnlineEvents;
using MAppAPI.ControllersServices.OnlineEventsServices;

namespace MAppAPI.Controllers.OnlineEventsControllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreateOnlineEventController : ControllerBase
    {
        private readonly ILogger<CreateOnlineEventController> _logger;
        OnlineEventCreationService creationService;

        public CreateOnlineEventController(ILogger<CreateOnlineEventController> logger, OnlineEventCreationService creationService)
        {
            _logger = logger;
            this.creationService = creationService;
        }

        [Authorize]
        [HttpPost]
        public async Task<string> CreateOnlineEvent([FromBody] OnlineEventRequest onlineEventRequest)
        {
            var userID = Request.GetUserID();
            if (userID < 1)
                return null;
            var isSucedded = await creationService.TryCreateEventAsync(onlineEventRequest, userID);
            if (!isSucedded)
                return null;
            return "1";
        }
    }
}
