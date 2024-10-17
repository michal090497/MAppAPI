using MApp.DataAccess.Models.OnlineEvents;
using MApp.DataAccess.Models.Users;
using MAppAPI.Models.Responses.EventsBase;
using MAppAPI.Models.Responses.Users;

namespace MAppAPI.Models.Responses.OnlineEvents;

public class OnlineEventInvitationForSending : IEventInvitationForSendingBase<OnlineEvent, OnlineEventForSending, OnlineEventCategory, OnlineEventInvitation, OnlineEventInvitationForSending>
{
    public OnlineEventForSending Event { get; set; }
    public SimplifiedUser InvitationAuthor { get; set; }
    private OnlineEventInvitationForSending() { }
    public static async Task<OnlineEventInvitationForSending> Create(OnlineEvent onlineEvent, User user)
    {
        var tempEvent = new OnlineEventInvitationForSending();
        tempEvent.Event = await OnlineEventForSending.Create(onlineEvent);
        tempEvent.InvitationAuthor = await SimplifiedUser.CreateFromUser(user);
        return tempEvent;
    }
    public static async Task<List<OnlineEventInvitationForSending>> CreateList(ICollection<OnlineEventInvitation> onlineEventInvitations)
    {
        List<OnlineEventInvitationForSending> listForSending = new List<OnlineEventInvitationForSending>();
        foreach (var invitation in onlineEventInvitations)
        {
            var author = invitation.Event.Users.FirstOrDefault(x => x.ID == invitation.AuthorID);
            if (author != null)
                listForSending.Add(await Create(invitation.Event, author));
        }
        return listForSending;
    }
}
