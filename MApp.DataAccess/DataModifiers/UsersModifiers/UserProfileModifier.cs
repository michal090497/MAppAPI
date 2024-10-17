using MApp.Common.Helpers;
using MApp.DataAccess.Context;
using MApp.DataAccess.Models.OnlineEvents;
using MApp.DataAccess.Models.PhysicalEvents;
using MApp.DataAccess.Models.Users;

namespace MApp.DataAccess.DataModifiers.UsersModifiers
{
    public class UserProfileModifier : DataModifierBase
    {
        public UserProfileModifier(MAppDbContext dbContext) : base(dbContext) { }
        public async Task SetDetails(User user, string bio, string languages, string hobbies, List<OnlineEventCategory> favouriteOnlineEventCategories, List<PhysicalEventCategory> favouritePhysicalEventCategories, string profilePicture)
        {
            if (bio != string.Empty)
                user.Bio = bio;
            if (languages != string.Empty)
                user.Languages = languages;
            if (hobbies != string.Empty)
                user.Hobbies = hobbies;
            if (favouriteOnlineEventCategories.Count != 0)
                user.FavouriteOnlineEventCategories = favouriteOnlineEventCategories;
            if (favouritePhysicalEventCategories.Count != 0)
                user.FavouritePhysicalEventCategories = favouritePhysicalEventCategories;
            if (profilePicture != null && profilePicture.Length > 0)
                user.ProfilePicturePath = await PictureHelper.ConvertProfilePictureFromStringAndSave(profilePicture, user.ID);
            await dbContext.SaveChangesAsync();
        }
        public async Task ChangeDetails(User user, string bio, string languages, string hobbies, List<OnlineEventCategory> favouriteOnlineEventCategories, List<PhysicalEventCategory> favouritePhysicalEventCategories, string profilePicture, string username)
        {
            await SetDetails(user, bio, languages, hobbies, favouriteOnlineEventCategories, favouritePhysicalEventCategories, profilePicture);
            if (username != string.Empty)
            {
                user.ChangeUserName(username);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
