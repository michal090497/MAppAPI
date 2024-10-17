namespace MAppAPI.Models.Requests.Users;

public class ChangeProfileDataRequest : ProfileDetailsRequest
{
    public string Username { get; set; } = string.Empty;
}
