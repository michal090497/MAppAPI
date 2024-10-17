using MApp.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace MApp.DataAccess.DataAccessors.PhysicalEventsInvitationsAccessors
{
    public class PhysicalEventInvitationAccessor : PhysicalEventInvitationAccessorBase
    {
        public PhysicalEventInvitationAccessor(MAppDbContext dbContext) : base(dbContext) { }
        public async override Task FindEntity(int entityID)
        {
            EventInvitation = await dbContext.PhysicalEventsInvitations
                .FirstOrDefaultAsync(x => x.ID == entityID);
        }
        public async override Task FindEntityWithBasicAssocs(int entityID)
        {
            EventInvitation = await dbContext.PhysicalEventsInvitations
                .Include(x => x.InvitedUser).Include(x => x.Event)
                .FirstOrDefaultAsync(x => x.ID == entityID);
        }
        public async override Task FindEntityWithDetailedAssocs(int entityID)
        {
            EventInvitation = await dbContext.PhysicalEventsInvitations
                .Include(x => x.InvitedUser).ThenInclude(x => x.OnlineEvents)
                .Include(x => x.Event).ThenInclude(x => x.Users)
                .FirstOrDefaultAsync(x => x.ID == entityID);
        }
        public async override Task FindEntityWithAllDetailedAssocs(int entityID) => await FindEntityWithDetailedAssocs(entityID);
    }
}
