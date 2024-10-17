namespace MAppAPI.Models.Requests.EventsStatuses;

public class CreateEventsStatusRequest : IEventStatusRequestBase
{
    public int EventID { get; set; }
    public string Content { get; set; } = string.Empty;
}
