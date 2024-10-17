using MApp.DataAccess.DataAccessors.UsersAccessors;
using MApp.DataAccess.DataModifiers.UsersModifiers;
using MApp.DataAccess.Models.Users;
using MAppAPI.Models.Requests.Users;

namespace MAppAPI.ControllersServices.UsersServices
{
    public class UserProfileService
    {
        UserAccessor userAccessor;
        UserProfileModifier profileModifier;
        public UserProfileService(UserAccessor userAccessor, UserProfileModifier profileModifier)
        {
            this.userAccessor = userAccessor;
            this.profileModifier = profileModifier;
        }
        public async Task<string> TrySetDetailsAsync(ProfileDetailsRequest detailsRequest, int userID)
        {
            await userAccessor.FindEntity(userID);
            if (userAccessor.User == null)
                return "user not found";
            await profileModifier.SetDetails(userAccessor.User, detailsRequest.Bio, detailsRequest.Languages, detailsRequest.Hobbies,
                detailsRequest.FavouriteOnlineEventCategories, detailsRequest.FavouritePhysicalEventCategories, detailsRequest.ProfilePicture);
            return "1";
        }
        public async Task<User> TryUpdateDetailsAsync(ChangeProfileDataRequest changeRequest, int userID)
        {
            await userAccessor.FindEntity(userID);
            if (userAccessor.User == null)
                return null;
            await profileModifier.ChangeDetails(userAccessor.User, changeRequest.Bio, changeRequest.Languages, changeRequest.Hobbies,
                changeRequest.FavouriteOnlineEventCategories, changeRequest.FavouritePhysicalEventCategories, changeRequest.ProfilePicture, changeRequest.Username);
            return userAccessor.User;
        }
    }
}
