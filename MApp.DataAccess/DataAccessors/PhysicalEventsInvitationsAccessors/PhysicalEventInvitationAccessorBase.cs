using MApp.DataAccess.Context;
using MApp.DataAccess.DataAccessors.AccesorsBase;
using MApp.DataAccess.Models.PhysicalEvents;

namespace MApp.DataAccess.DataAccessors.PhysicalEventsInvitationsAccessors
{
    public abstract class PhysicalEventInvitationAccessorBase : IEventsInvitationsAccessor<PhysicalEventInvitation, PhysicalEvent>
    {
        public PhysicalEventInvitation EventInvitation { get; protected set; }
        public MAppDbContext dbContext { get; protected set; }

        public PhysicalEventInvitationAccessorBase(MAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public abstract Task FindEntity(int entityID);
        public abstract Task FindEntityWithBasicAssocs(int entityID);
        public abstract Task FindEntityWithDetailedAssocs(int entityID);
        public abstract Task FindEntityWithAllDetailedAssocs(int entityID);
    }
}
