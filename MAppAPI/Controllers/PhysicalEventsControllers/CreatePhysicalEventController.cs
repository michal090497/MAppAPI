using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MApp.Common.Extensions;
using MAppAPI.Models.Requests.PhysicalEvents;
using MAppAPI.ControllersServices.PhysicalEventsServices;

namespace MAppAPI.Controllers.PhysicalEventsControllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreatePhysicalEventController : ControllerBase
    {
        private readonly ILogger<CreatePhysicalEventController> _logger;
        PhysicalEventCreationService creationService;

        public CreatePhysicalEventController(ILogger<CreatePhysicalEventController> logger, PhysicalEventCreationService creationService)
        {
            _logger = logger;
            this.creationService = creationService;
        }

        [Authorize]
        [HttpPost]
        public async Task<string> CreatePhysicalEvent([FromBody] PhysicalEventRequest physicalEventRequest)
        {
            var userID = Request.GetUserID();
            if (userID < 1)
                return null;
            var isSucedded = await creationService.TryCreateEventAsync(physicalEventRequest, userID);
            if (!isSucedded)
                return null;
            return "1";
        }
    }
}
