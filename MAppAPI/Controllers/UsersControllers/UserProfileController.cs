using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MApp.Common.Extensions;
using MAppAPI.Models.Responses.Users;
using MAppAPI.Models.Requests.Users;
using MApp.DataAccess.DataAccessors.UsersAccessors;
using MAppAPI.ControllersServices.UsersServices;

namespace MAppAPI.Controllers.UsersControllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserProfileController : ControllerBase
    {
        private readonly ILogger<UserProfileController> _logger;
        UserProfileService userProfileService;
        UserAccessor userAccessor;
        UserWithContactInvitationsAccessor userWithContactInvitationsAccessor;
        public UserProfileController(ILogger<UserProfileController> logger, UserAccessor userAccessor, UserProfileService userProfileService, UserWithContactInvitationsAccessor userWithContactInvitationsAccessor)
        {
            _logger = logger;
            this.userAccessor = userAccessor;
            this.userProfileService = userProfileService;
            this.userWithContactInvitationsAccessor = userWithContactInvitationsAccessor;
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<DetailedUserForSending> GetUserProfile(int id)
        {
            var userID = Request.GetUserID();
            if (userID < 1)
                return null;
            await userWithContactInvitationsAccessor.FindEntityWithBasicAssocs(userID);
            var requestAuthor = userWithContactInvitationsAccessor.User;
            if (requestAuthor == null)
                return null;
            await userAccessor.FindEntityWithBasicAssocs(id);
            var requestedUser = userAccessor.User;
            if (requestedUser == null)
                return null;
            var invitation = requestAuthor.Invitations.FirstOrDefault(x => x.InvitationAuthorID == requestedUser.ID);
            var invitationID = invitation != null ? invitation.ID : -1;
            var userForSending = await DetailedUserForSending.Create(requestedUser, true, invitationID, invitationID > -1, requestedUser.Contacts.Any(x => x.ID == userID));
            return userForSending;
        }

        [Authorize]
        [HttpPost]
        public async Task<DetailedUserForSending> ChangeProfileData([FromBody] ChangeProfileDataRequest changeRequest)
        {
            var userID = Request.GetUserID();
            if (userID < 1)
                return null;
            var tempUser = await userProfileService.TryUpdateDetailsAsync(changeRequest, userID);
            if (tempUser == null)
                return null;
            return await DetailedLoggedUserForSending.CreateWithDetails(tempUser, true);
        }
    }
}
