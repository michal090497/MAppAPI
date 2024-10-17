using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MApp.Common.Extensions;
using MAppAPI.Models.Responses.EventsStatuses;
using MApp.DataAccess.DataAccessors.UsersAccessors;
using MApp.DataAccess.DataAccessors.EventsStatusesAccessors;
using MAppAPI.Validators.EventsStatusesValidators;

namespace MAppAPI.Controllers.EventsStatusesControllers
{
    [ApiController]
    [Route("[controller]")]
    public class UpdateEventsStatusController : ControllerBase
    {
        private readonly ILogger<NewConversationController> _logger;
        UserAccessor userAccessor;
        EventStatusAccessor eventStatusAccessor;
        UserAttendanceValidator attendanceValidator;

        public UpdateEventsStatusController(ILogger<NewConversationController> logger, UserAccessor userAccessor, EventStatusAccessor eventStatusAccessor, UserAttendanceValidator attendanceValidator)
        {
            _logger = logger;
            this.userAccessor = userAccessor;
            this.eventStatusAccessor = eventStatusAccessor;
            this.attendanceValidator = attendanceValidator;
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<EventsStatusForSending> UpdateStatus(int id)
        {
            var userID = Request.GetUserID();
            if (userID < 1)
                return null;
            await userAccessor.FindEntity(userID);
            if (userAccessor.User == null)
                return null;
            await eventStatusAccessor.FindEntityWithAllDetailedAssocs(id);
            if (attendanceValidator.CheckAttendance(userAccessor.User, eventStatusAccessor.UserStatus))
                return null;
            return await EventsStatusForSending.Create(eventStatusAccessor.UserStatus);
        }
    }
}
