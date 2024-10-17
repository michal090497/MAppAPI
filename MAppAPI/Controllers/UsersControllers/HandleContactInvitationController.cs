using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MApp.Common.Extensions;
using MAppAPI.Models.Requests.Users;
using MAppAPI.ControllersServices.UsersServices;

namespace MAppAPI.Controllers.UsersControllers
{
    [ApiController]
    [Route("[controller]")]
    public class HandleContactInvitationController : ControllerBase
    {
        private readonly ILogger<HandleContactInvitationController> _logger;
        ContactInvitationsService invitationsService;
        public HandleContactInvitationController(ILogger<HandleContactInvitationController> logger, ContactInvitationsService invitationsService)
        {
            _logger = logger;
            this.invitationsService = invitationsService;
        }
        [Authorize]
        [HttpPost]
        public async Task<string> HandleInvitation([FromBody] ContactInvitationResponseRequest responseRequest)
        {
            var userID = Request.GetUserID();
            if (userID < 1)
                return null;
            return await invitationsService.TryHandleInvitationAsync(responseRequest, userID);
        }
    }
}
