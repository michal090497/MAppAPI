using MAppAPI.Models.Responses.Users;

namespace MAppAPI.Models.Responses.EventsStatuses
{
    public interface IEventsStatusForSendingBase
    {
        public int ID { get; set; }
        public DateTime ServerReceptionTimeGMT { get; set; }
        public SimplifiedUser Creator { get; set; }
        public string Content { get; set; }
    }
}
