using MApp.DataAccess.Models.Users;

namespace MAppAPI.Models.Responses.Users;

public class TempUser : IBasicUser
{
    public int ID { get; set; }
    public string Username { get; set; }
    public int UserLevel { get; set; }
    public string Token { get; set; }

    public TempUser(User user)
    {
        Username = user.Username;
        UserLevel = user.UserLevel;
        ID = user.ID;
    }
    public TempUser(User user, string token) : this(user)
    {
        this.Token = token;
    }
    public TempUser()
    {

    }
}
