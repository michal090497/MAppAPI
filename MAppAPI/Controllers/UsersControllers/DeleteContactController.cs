using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MApp.Common.Extensions;
using MAppAPI.ControllersServices.UsersServices;

namespace MAppAPI.Controllers.UsersControllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeleteContactController : ControllerBase
    {
        private readonly ILogger<DeleteContactController> _logger;
        ContactsService contactsService;
        public DeleteContactController(ILogger<DeleteContactController> logger, ContactsService contactsService)
        {
            _logger = logger;
            this.contactsService = contactsService;
        }
        [Authorize]
        [HttpPost]
        public async Task<string> DeleteContact([FromBody] int contactToBeDeletedUserID)
        {
            var userID = Request.GetUserID();
            if (userID < 1)
                return null;
            return await contactsService.TryDeleteContactAsync(contactToBeDeletedUserID, userID);
        }
    }
}
