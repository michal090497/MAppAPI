using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MApp.Common.Extensions;
using MApp.DataAccess.DataAccessors.UsersAccessors;
using MApp.Common.Helpers;

namespace MAppAPI.Controllers.UsersControllers
{
    [ApiController]
    [Route("[controller]")]
    public class RenewTokenController : ControllerBase
    {
        private readonly ILogger<RenewTokenController> _logger;
        UserAccessor userAccessor;
        private IConfiguration _config;
        JWTHelper jWTHelper;

        public RenewTokenController(ILogger<RenewTokenController> logger, UserAccessor userAccessor, IConfiguration config, JWTHelper jWTHelper)
        {
            _logger = logger;
            this.userAccessor = userAccessor;
            _config = config;
            this.jWTHelper = jWTHelper;
        }

        [Authorize]
        [HttpPost]
        public async Task<string> RenewToken()
        {
            var userID = Request.GetUserID();
            if (userID < 1)
                return null;
            await userAccessor.FindEntity(userID);
            if (userAccessor.User == null)
                return null;
            var token = jWTHelper.GenerateAndSaveUserToken(userAccessor.User.ID);
            return token;
        }
    }
}
