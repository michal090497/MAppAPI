using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MApp.Common.Extensions;
using MAppAPI.Models.Responses.EventsStatuses;
using MAppAPI.Models.Requests.EventsStatuses;
using MAppAPI.ControllersServices.EventsStatusesServices;

namespace MAppAPI.Controllers.EventsStatusesControllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddCommentToStatusController : ControllerBase
    {
        private readonly ILogger<NewConversationController> _logger;
        EventStatusCommentsService commentsService;


        public AddCommentToStatusController(ILogger<NewConversationController> logger, EventStatusCommentsService commentsService)
        {
            _logger = logger;
            this.commentsService = commentsService;
        }

        [Authorize]
        [HttpPost]
        public async Task<EventsStatusForSending> AddComment([FromBody] AddCommentToStatusRequest createCommentRequest)
        {
            var userID = Request.GetUserID();
            if (userID < 1)
                return null;
            var status = await commentsService.TryAddCommentAsync(createCommentRequest, userID);
            if (status == null)
                return null;
            return await EventsStatusForSending.Create(status);
        }
    }
}
