using MApp.Common.Helpers;
using MApp.DataAccess.Models.Users;

namespace MAppAPI.Models.Responses.Users;

public class SimplifiedUser : IBasicUser
{
    public int ID { get; set; }
    public string Username { get; set; }
    public string ProfilePicture { get; set; }
    public SimplifiedUser() { }
    public static async Task<SimplifiedUser> CreateFromUser(User user)
    {
        var tempUser = new SimplifiedUser
        {
            ID = user.ID,
            Username = user.Username,
            ProfilePicture = await PictureHelper.ConvertProfilePictureToString(user.ID)
        };
        return tempUser;
    }
    public static async Task<List<SimplifiedUser>> CreateFromICollection(ICollection<User> users)
    {
        var outputList = new List<SimplifiedUser>();
        foreach (var item in users)
        {
            outputList.Add(await CreateFromUser(item));
        }
        return outputList;
    }
}
