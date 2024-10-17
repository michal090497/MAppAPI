using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MApp.Common.Extensions;
using MAppAPI.Models.Responses.Users;
using MApp.DataAccess.DataAccessors.UsersAccessors;

namespace MAppAPI.Controllers.UsersControllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetLoggedUserController : ControllerBase
    {
        private readonly ILogger<GetLoggedUserController> _logger;
        UserAccessor userAccessor;
        public GetLoggedUserController(ILogger<GetLoggedUserController> logger, UserAccessor userAccessor)
        {
            _logger = logger;
            this.userAccessor = userAccessor;
        }

        [Authorize]
        [HttpPost]
        public async Task<DetailedLoggedUserForSending> GetProfile()
        {
            var userID = Request.GetUserID();
            if (userID < 1)
                return null;
            await userAccessor.GetLoggedUser(userID);
            if (userAccessor.User == null)
                return null;
            return await DetailedLoggedUserForSending.CreateWithDetails(userAccessor.User, true);
        }
    }
}
