namespace MApp.DataAccess.Models.EventsBase
{
    public interface IEventDetailsBase : IEntityBase
    {
        public string Details { get; set; }
        public string WayOfContact { get; set; }
        public string ContactDetails { get; set; }
    }
}
