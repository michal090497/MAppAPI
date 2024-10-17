using MApp.DataAccess.Models;
using MApp.DataAccess.Models.Users;

namespace MApp.DataAccess.DataModifiers.EventsStatusesModifiers
{
    public interface IEventStatusModifiersBase<DataType> : IDataModifierBase 
        where DataType : IEntityBase
    {
        public async Task Create(DataType baseEntity, string content, User user) { }
    }
}
