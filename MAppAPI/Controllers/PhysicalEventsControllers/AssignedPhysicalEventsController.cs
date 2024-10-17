using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MApp.Common.Extensions;
using MAppAPI.Models.Responses.PhysicalEvents;
using MApp.DataAccess.DataAccessors.UsersAccessors;

namespace MAppAPI.Controllers.PhysicalEventsControllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssignedPhysicalEventsController : ControllerBase
    {
        private readonly ILogger<AssignedPhysicalEventsController> _logger;
        UserWithPhysicalEventsAccessor physicalEventsAccessor;

        public AssignedPhysicalEventsController(ILogger<AssignedPhysicalEventsController> logger, UserWithPhysicalEventsAccessor physicalEventsAccessor)
        {
            _logger = logger;
            this.physicalEventsAccessor = physicalEventsAccessor;
        }

        [Authorize]
        [HttpGet]
        public async Task<List<PhysicalEventForSendingWithDetails>> GetListOfAttendedPhysicalEvents()
        {
            var userID = Request.GetUserID();
            if (userID < 1)
                return new List<PhysicalEventForSendingWithDetails>();
            await physicalEventsAccessor.FindEntity(userID);
            if (physicalEventsAccessor.User == null)
                return new List<PhysicalEventForSendingWithDetails>();
            return PhysicalEventForSendingWithDetails.CreateListWithDetails(physicalEventsAccessor.User.PhysicalEvents.ToList(), 0);
        }
    }
}
