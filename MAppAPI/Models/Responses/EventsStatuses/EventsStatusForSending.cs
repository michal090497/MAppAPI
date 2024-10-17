using MApp.DataAccess.Models.EventsStatuses;
using MAppAPI.Models.Responses.Users;

namespace MAppAPI.Models.Responses.EventsStatuses;

public class EventsStatusForSending : IEventsStatusForSendingBase
{
    public int ID { get; set; }
    public DateTime ServerReceptionTimeGMT { get; set; }
    public SimplifiedUser Creator { get; set; }
    public string Content { get; set; }
    public virtual List<EventsStatusCommentForSending> Comments { get; set; }
    private EventsStatusForSending(EventStatus status)
    {
        ID = status.ID;
        ServerReceptionTimeGMT = status.CreationTimeGMT;
        Content = status.Content;
    }
    public static async Task<EventsStatusForSending> Create(EventStatus status)
    {
        var userStatus = await CreateWithoutComments(status);
        userStatus.Comments = await EventsStatusCommentForSending.ConvertList(status.Comments);
        return userStatus;
    }
    public static async Task<EventsStatusForSending> CreateWithoutComments(EventStatus status)
    {
        var userStatus = new EventsStatusForSending(status);
        userStatus.Creator = await SimplifiedUser.CreateFromUser(status.Creator);
        return userStatus;
    }
    public static async Task<List<EventsStatusForSending>> ConvertList(IEnumerable<EventStatus> list)
    {
        var listForSending = new List<EventsStatusForSending>();
        foreach (var item in list)
            listForSending.Add(await Create(item));
        return listForSending;
    }
    public static async Task<List<EventsStatusForSending>> ConvertListWithoutComments(IEnumerable<EventStatus> list)
    {
        var listForSending = new List<EventsStatusForSending>();
        foreach (var item in list)
            listForSending.Add(await CreateWithoutComments(item));
        return listForSending;
    }
}
