using MApp.DataAccess.Models.Users;

namespace MApp.DataAccess.Models.EventsStatuses
{
    public interface IEventsStatusesBase : IEntityBase
    {
        public User Creator { get; set; }
        public DateTime CreationTimeGMT { get; set; }
        public string Content { get; set; }
    }
}
