using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MApp.Common.Extensions;
using MAppAPI.Models.Responses.EventsStatuses;
using MApp.DataAccess.DataAccessors.UsersAccessors;
using MApp.DataAccess.DataAccessors.OnlineEventsAccessors;

namespace MAppAPI.Controllers.EventsStatusesControllers
{
    [ApiController]
    [Route("[controller]")]
    public class UpdateOnlineEventsStatusesController : ControllerBase
    {
        private readonly ILogger<NewConversationController> _logger;
        UserAccessor userAccessor;
        OnlineEventAccessor eventAccessor;

        public UpdateOnlineEventsStatusesController(ILogger<NewConversationController> logger, UserAccessor userAccessor, OnlineEventAccessor eventAccessor)
        {
            _logger = logger;
            this.userAccessor = userAccessor;
            this.eventAccessor = eventAccessor;
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<List<EventsStatusForSending>> UpdateStatuses(int id)
        {
            var userID = Request.GetUserID();
            if (userID < 1)
                return new List<EventsStatusForSending>();
            await userAccessor.FindEntity(userID);
            if (userAccessor.User == null)
                return new List<EventsStatusForSending>();
            await eventAccessor.FindEventWithStatuses(id);
            if (eventAccessor.Event == null || !eventAccessor.Event.Users.Any(x => x.ID == userID))
                return new List<EventsStatusForSending>();
            return await EventsStatusForSending.ConvertListWithoutComments(eventAccessor.Event.Statuses);
        }
    }
}
