using MApp.DataAccess.Models.PhysicalEvents;
using MApp.DataAccess.Models.Users;
using MAppAPI.Models.Responses.EventsBase;
using MAppAPI.Models.Responses.Users;

namespace MAppAPI.Models.Responses.PhysicalEvents;

public class PhysicalEventInvitationForSending : IEventInvitationForSendingBase<PhysicalEvent, PhysicalEventForSending, PhysicalEventCategory, PhysicalEventInvitation, PhysicalEventInvitationForSending>
{
    public PhysicalEventForSending Event { get; set; }
    public SimplifiedUser InvitationAuthor { get; set; }
    private PhysicalEventInvitationForSending() { }
    public static async Task<PhysicalEventInvitationForSending> Create(PhysicalEvent physicalEvent, User user)
    {
        var tempEvent = new PhysicalEventInvitationForSending();
        tempEvent.Event = await PhysicalEventForSending.Create(physicalEvent);
        tempEvent.InvitationAuthor = await SimplifiedUser.CreateFromUser(user);
        return tempEvent;
    }
    public static async Task<List<PhysicalEventInvitationForSending>> CreateList(ICollection<PhysicalEventInvitation> physicalEventInvitations)
    {
        List<PhysicalEventInvitationForSending> listForSending = new List<PhysicalEventInvitationForSending>();
        foreach (var invitation in physicalEventInvitations)
        {
            var author = invitation.Event.Users.FirstOrDefault(x => x.ID == invitation.AuthorID);
            if (author != null)
                listForSending.Add(await Create(invitation.Event, author));
        }
        return listForSending;
    }
}
