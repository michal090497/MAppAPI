using MApp.DataAccess.Context;
using MApp.DataAccess.DataAccessors.AccesorsBase;
using MApp.DataAccess.Models.EventsStatuses;

namespace MApp.DataAccess.DataAccessors.EventsStatusesAccessors
{
    public abstract class EventStatusAccessorBase : IEventStatusAccessor
    {
        public EventStatus UserStatus { get; protected set; }
        public MAppDbContext dbContext { get; protected set; }

        public EventStatusAccessorBase(MAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public abstract Task FindEntity(int entityID);
        public abstract Task FindEntityWithBasicAssocs(int entityID);
        public abstract Task FindEntityWithDetailedAssocs(int entityID);
        public abstract Task FindEntityWithAllDetailedAssocs(int entityID);
    }
}
