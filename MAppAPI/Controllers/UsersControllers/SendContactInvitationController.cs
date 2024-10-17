using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MApp.Common.Extensions;
using MAppAPI.ControllersServices.UsersServices;

namespace MAppAPI.Controllers.UsersControllers
{
    [ApiController]
    [Route("[controller]")]
    public class SendContactInvitationController : ControllerBase
    {
        private readonly ILogger<SendContactInvitationController> _logger;
        ContactInvitationsService invitationsService;
        public SendContactInvitationController(ILogger<SendContactInvitationController> logger, ContactInvitationsService invitationsService)
        {
            _logger = logger;
            this.invitationsService = invitationsService;
        }
        [Authorize]
        [HttpPost]
        public async Task<string> SendInvitation([FromBody] int receiverID)
        {
            var userID = Request.GetUserID();
            if (userID < 1)
                return "wrong ID";
            return await invitationsService.TryCreateInvitationAsync(receiverID, userID);
        }
    }
}
