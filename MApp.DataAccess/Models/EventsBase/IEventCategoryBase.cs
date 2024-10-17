using MApp.DataAccess.Models.Users;

namespace MApp.DataAccess.Models.EventsBase
{
    public interface IEventCategoryBase : IEntityBase
    {
        public string CategoryName { get; set; }
        public ICollection<User> FavouriteFor { get; set; }
    }
}
