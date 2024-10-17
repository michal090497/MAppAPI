using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MApp.Common.Extensions;
using MAppAPI.Models.Responses.PhysicalEvents;
using MAppAPI.ControllersServices.PhysicalEventsServices;

namespace MAppAPI.Controllers.PhysicalEventsControllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetSinglePhysicalEventInfoController : ControllerBase
    {
        private readonly ILogger<GetSinglePhysicalEventInfoController> _logger;
        PhysicalEventInfoService infoService;

        public GetSinglePhysicalEventInfoController(ILogger<GetSinglePhysicalEventInfoController> logger, PhysicalEventInfoService infoService)
        {
            _logger = logger;
            this.infoService = infoService;
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<PhysicalEventForSendingWithDetails> GetInfo(int id)
        {
            var userID = Request.GetUserID();
            if (userID < 1)
                return null;
            var tempEvent = await infoService.TryGetInfoWithDetailsAsync(id, userID);
            if (tempEvent == null)
                return null;
            return await PhysicalEventForSendingWithDetails.CreateWithDetails(tempEvent);
        }
    }
}
