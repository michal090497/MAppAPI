using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MApp.Common.Extensions;
using MAppAPI.Models.Responses.OnlineEvents;
using MAppAPI.ControllersServices.OnlineEventsServices;

namespace MAppAPI.Controllers.OnlineEventsControllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetSingleOnlineEventInfoController : ControllerBase
    {
        private readonly ILogger<GetSingleOnlineEventInfoController> _logger;
        OnlineEventInfoService infoService;

        public GetSingleOnlineEventInfoController(ILogger<GetSingleOnlineEventInfoController> logger, OnlineEventInfoService infoService)
        {
            _logger = logger;
            this.infoService = infoService;
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<OnlineEventForSendingWithDetails> GetInfoWithDetails(int id)
        {
            var userID = Request.GetUserID();
            if (userID < 1)
                return null;
            var tempEvent = await infoService.TryGetInfoWithDetailsAsync(id, userID);
            if (tempEvent == null)
                return null;
            return await OnlineEventForSendingWithDetails.CreateWithDetails(tempEvent);
        }
    }
}
