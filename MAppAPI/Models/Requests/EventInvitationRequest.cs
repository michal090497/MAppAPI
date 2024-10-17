namespace MAppAPI.Models.Requests;

public class EventInvitationRequest
{
    public int EventID { get; set; }
    public int InvitedUserID { get; set; }
}
