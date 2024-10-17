namespace MAppAPI.Models.Requests.EventsStatuses;

public class AddCommentToStatusRequest : IEventStatusRequestBase
{
    public int StatusID { get; set; }
    public string Content { get; set; } = string.Empty;
}
