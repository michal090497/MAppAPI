using MApp.DataAccess.Context;
using MApp.DataAccess.DataAccessors.AccesorsBase;
using MApp.DataAccess.Models.OnlineEvents;

namespace MApp.DataAccess.DataAccessors.OnlineEventsAccessors
{
    public abstract class OnlineEventAccessorBase : IEventsAccesor<OnlineEvent>
    {
        public OnlineEvent Event { get; protected set; }
        public MAppDbContext dbContext { get; protected set; }

        public OnlineEventAccessorBase(MAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public abstract Task FindEntity(int entityID);
        public abstract Task FindEntityWithBasicAssocs(int entityID);
        public abstract Task FindEntityWithDetailedAssocs(int entityID);
        public abstract Task FindEntityWithAllDetailedAssocs(int entityID);
    }
}
