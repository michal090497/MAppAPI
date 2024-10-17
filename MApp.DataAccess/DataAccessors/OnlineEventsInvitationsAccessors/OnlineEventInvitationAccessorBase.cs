using MApp.DataAccess.Context;
using MApp.DataAccess.DataAccessors.AccesorsBase;
using MApp.DataAccess.Models.OnlineEvents;

namespace MApp.DataAccess.DataAccessors.OnlineEventsInvitationsAccessors
{
    public abstract class OnlineEventInvitationAccessorBase : IEventsInvitationsAccessor<OnlineEventInvitation, OnlineEvent>
    {
        public OnlineEventInvitation EventInvitation { get; protected set; }
        public MAppDbContext dbContext { get; protected set; }

        public OnlineEventInvitationAccessorBase(MAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public abstract Task FindEntity(int entityID);
        public abstract Task FindEntityWithBasicAssocs(int entityID);
        public abstract Task FindEntityWithDetailedAssocs(int entityID);
        public abstract Task FindEntityWithAllDetailedAssocs(int entityID);
    }
}
