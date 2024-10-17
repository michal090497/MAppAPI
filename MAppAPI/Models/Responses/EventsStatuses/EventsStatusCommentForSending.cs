using MApp.DataAccess.Models.EventsStatuses;
using MAppAPI.Models.Responses.Users;

namespace MAppAPI.Models.Responses.EventsStatuses;

public class EventsStatusCommentForSending : IEventsStatusForSendingBase
{
    public int ID { get; set; }
    public DateTime ServerReceptionTimeGMT { get; set; }
    public SimplifiedUser Creator { get; set; }
    public string Content { get; set; }
    private EventsStatusCommentForSending(EventStatusComment comment)
    {
        ID = comment.ID;
        ServerReceptionTimeGMT = comment.CreationTimeGMT;
        Content = comment.Content;
    }
    public static async Task<EventsStatusCommentForSending> Create(EventStatusComment comment)
    {
        var userComment = new EventsStatusCommentForSending(comment);
        userComment.Creator = await SimplifiedUser.CreateFromUser(comment.Creator);
        return userComment;
    }
    public static async Task<List<EventsStatusCommentForSending>> ConvertList(IEnumerable<EventStatusComment> list)
    {
        var listForSending = new List<EventsStatusCommentForSending>();
        foreach (var item in list)
            listForSending.Add(await Create(item));
        return listForSending;
    }
}
