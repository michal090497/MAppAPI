using MApp.Common.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MAppAPI.Models.Responses.EventsStatuses;
using MAppAPI.Models.Requests.EventsStatuses;
using MAppAPI.ControllersServices.EventsStatusesServices;

namespace MAppAPI.Controllers.EventsStatusesControllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreateOnlineEventsStatusController : ControllerBase
    {
        private readonly ILogger<NewConversationController> _logger;
        OnlineEventStatusCreationService creationService;

        public CreateOnlineEventsStatusController(ILogger<NewConversationController> logger, OnlineEventStatusCreationService creationService)
        {
            _logger = logger;
            this.creationService = creationService;
        }

        [Authorize]
        [HttpPost]
        public async Task<List<EventsStatusForSending>> CreateStatus([FromBody] CreateEventsStatusRequest createEventsStatusRequest)
        {
            var userID = Request.GetUserID();
            if (userID < 1)
                return new List<EventsStatusForSending>();
            var statuses = await creationService.TryCreateEventStatusAsync(createEventsStatusRequest, userID);
            if (statuses == null)
                return new List<EventsStatusForSending>();
            return await EventsStatusForSending.ConvertList(statuses);
        }
    }
}
