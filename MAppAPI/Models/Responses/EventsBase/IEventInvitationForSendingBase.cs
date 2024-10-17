using MApp.DataAccess.Models.EventsBase;
using MApp.DataAccess.Models.Users;
using MAppAPI.Models.Responses.Users;

namespace MAppAPI.Models.Responses.EventsBase
{
    public interface IEventInvitationForSendingBase<EventType, EventForSendingType, EventCategory, EventInvitationType, EventInvitationForSendingType>
        where EventCategory : IEventCategoryBase 
        where EventForSendingType : IEventForSendingBase<EventType, EventForSendingType, EventCategory>
        where EventType : IEventBase
        where EventInvitationType : IEventInvitationBase<EventType>
        where EventInvitationForSendingType : IEventInvitationForSendingBase<EventType, EventForSendingType, EventCategory, EventInvitationType, EventInvitationForSendingType>
    {
        public EventForSendingType Event { get; set; }
        public SimplifiedUser InvitationAuthor { get; set; }
        public static Task<EventInvitationForSendingType?> Create(EventType tempEvent, User user) { return null; }
        public static async Task<List<EventInvitationForSendingType>> CreateList(ICollection<EventInvitationType> tempEventInvitations) { return null; }
    }
}
