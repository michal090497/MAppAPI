using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MApp.Common.Extensions;
using MAppAPI.Models.Responses.PhysicalEvents;
using MApp.DataAccess.DataAccessors.UsersAccessors;

namespace MAppAPI.Controllers.PhysicalEventsControllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhysicalEventInvitationsController : ControllerBase
    {
        private readonly ILogger<PhysicalEventInvitationsController> _logger;
        UserWithPhysicalEventsInvitationsAccessor userAccessor;
        public PhysicalEventInvitationsController(ILogger<PhysicalEventInvitationsController> logger, UserWithPhysicalEventsInvitationsAccessor userAccessor)
        {
            _logger = logger;
            this.userAccessor = userAccessor;
        }
        [Authorize]
        [HttpGet]
        public async Task<List<PhysicalEventInvitationForSending>> ReturnInvitationList()
        {
            var userID = Request.GetUserID();
            if (userID < 1)
                return new List<PhysicalEventInvitationForSending>();
            await userAccessor.FindEntityWithDetailedAssocs(userID);
            if (userAccessor.User == null)
                return new List<PhysicalEventInvitationForSending>();
            var listForSending = await PhysicalEventInvitationForSending.CreateList(userAccessor.User.PhysicalEventsInvitations);
            return listForSending;
        }
    }
}
