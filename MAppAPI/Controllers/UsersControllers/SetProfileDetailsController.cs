using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MApp.Common.Extensions;
using MAppAPI.Models.Requests.Users;
using MAppAPI.ControllersServices.UsersServices;

namespace MAppAPI.Controllers.UsersControllers
{
    [ApiController]
    [Route("[controller]")]
    public class SetProfileDetailsController : ControllerBase
    {
        private readonly ILogger<SetProfileDetailsController> _logger;
        UserProfileService userProfileService;
        public SetProfileDetailsController(ILogger<SetProfileDetailsController> logger, UserProfileService userProfileService)
        {
            _logger = logger;
            this.userProfileService = userProfileService;
        }

        [Authorize]
        [HttpPost]
        public async Task<string> SetDetails([FromBody] ProfileDetailsRequest detailsRequest)
        {
            var userID = Request.GetUserID();
            if (userID < 1)
                return "wrong ID";
            return await userProfileService.TrySetDetailsAsync(detailsRequest, userID);
        }
    }
}
