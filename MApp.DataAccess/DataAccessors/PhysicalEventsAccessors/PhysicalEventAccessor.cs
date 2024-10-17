using MApp.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace MApp.DataAccess.DataAccessors.PhysicalEventsAccessors
{
    public class PhysicalEventAccessor : PhysicalEventAccessorBase
    {
        public PhysicalEventAccessor(MAppDbContext dbContext) : base(dbContext) { }
        public async override Task FindEntity(int entityID)
        {
            Event = await dbContext.PhysicalEvents
                .FirstOrDefaultAsync(x => x.ID == entityID);
        }
        public async override Task FindEntityWithBasicAssocs(int entityID)
        {
            Event = await dbContext.PhysicalEvents
                .Include(x => x.Attendees).Include(x => x.Category)
                .Include(x => x.Details).Include(x => x.Users)
                .Include(x => x.Statuses).Include(x => x.InvitedUsers)
                .FirstOrDefaultAsync(x => x.ID == entityID);
        }
        public async override Task FindEntityWithDetailedAssocs(int entityID)
        {
            Event = await dbContext.PhysicalEvents
                .Include(x => x.Attendees).Include(x => x.Category)
                .Include(x => x.Details).Include(x => x.Users)
                .Include(x => x.Statuses).ThenInclude(x => x.Creator)
                .Include(x => x.InvitedUsers).ThenInclude(x => x.InvitedUser)
                .FirstOrDefaultAsync(x => x.ID == entityID);
        }
        public async override Task FindEntityWithAllDetailedAssocs(int entityID) => await FindEntityWithDetailedAssocs(entityID);
        public async Task FindEventWithStatuses(int entityID)
        {
            Event = await dbContext.PhysicalEvents
                .Include(x => x.Users).Include(x => x.Statuses).ThenInclude(x => x.Creator)
                .FirstOrDefaultAsync(x => x.ID == entityID);
        }
    }
}
