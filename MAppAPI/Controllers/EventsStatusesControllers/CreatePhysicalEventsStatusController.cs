using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MApp.Common.Extensions;
using MAppAPI.Models.Responses.EventsStatuses;
using MAppAPI.Models.Requests.EventsStatuses;
using MAppAPI.ControllersServices.EventsStatusesServices;

namespace MAppAPI.Controllers.EventsStatusesControllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreatePhysicalEventsStatusController : ControllerBase
    {
        private readonly ILogger<NewConversationController> _logger;
        PhysicalEventStatusCreationService creationService;

        public CreatePhysicalEventsStatusController(ILogger<NewConversationController> logger, PhysicalEventStatusCreationService creationService)
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
