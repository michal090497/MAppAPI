using MApp.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace MApp.DataAccess.DataAccessors.OnlineEventsInvitationsAccessors
{
    public class OnlineEventInvitationAccessor : OnlineEventInvitationAccessorBase
    {
        public OnlineEventInvitationAccessor(MAppDbContext dbContext) : base(dbContext) { }
        public async override Task FindEntity(int entityID)
        {
            EventInvitation = await dbContext.OnlineEventsInvitations
                .FirstOrDefaultAsync(x => x.ID == entityID);
        }
        public async override Task FindEntityWithBasicAssocs(int entityID)
        {
            EventInvitation = await dbContext.OnlineEventsInvitations
                .Include(x => x.InvitedUser).Include(x => x.ID)
                .FirstOrDefaultAsync(x => x.ID == entityID);
        }
        public async override Task FindEntityWithDetailedAssocs(int entityID)
        {
            EventInvitation = await dbContext.OnlineEventsInvitations
                .Include(x => x.InvitedUser).ThenInclude(x => x.OnlineEvents)
                .Include(x => x.Event).ThenInclude(x => x.InvitedUsers)
                .FirstOrDefaultAsync(x => x.ID == entityID);
        }
        public async override Task FindEntityWithAllDetailedAssocs(int entityID) => await FindEntityWithDetailedAssocs(entityID);
    }
}
