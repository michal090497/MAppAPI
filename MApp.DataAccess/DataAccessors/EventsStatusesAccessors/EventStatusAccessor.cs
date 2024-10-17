using MApp.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace MApp.DataAccess.DataAccessors.EventsStatusesAccessors
{
    public class EventStatusAccessor : EventStatusAccessorBase
    {

        public EventStatusAccessor(MAppDbContext dbContext) : base(dbContext) { }
        public async override Task FindEntity(int entityID)
        {
            UserStatus = await dbContext.EventsStatuses
                .FirstOrDefaultAsync(x => x.ID == entityID);
        }
        public async override Task FindEntityWithBasicAssocs(int entityID)
        {
            UserStatus = await dbContext.EventsStatuses
                .Include(x => x.OnlineEvent).Include(x => x.PhysicalEvent)
                .Include(x => x.Comments)
                .FirstOrDefaultAsync(x => x.ID == entityID);
        }
        public async override Task FindEntityWithDetailedAssocs(int entityID)
        {
            UserStatus = await dbContext.EventsStatuses
                .Include(x => x.OnlineEvent).Include(x => x.PhysicalEvent)
                .Include(x => x.Comments).ThenInclude(x => x.Creator)
                .FirstOrDefaultAsync(x => x.ID == entityID);
        }
        public async override Task FindEntityWithAllDetailedAssocs(int entityID)
        {
            await FindEntityWithDetailedAssocs(entityID);
            if (UserStatus != null)
            {
                if (UserStatus.OnlineEvent != null)
                    dbContext.OnlineEvents.Entry(UserStatus.OnlineEvent).Collection(x => x.Users).Query().Load();
                else if(UserStatus.PhysicalEvent != null)
                    dbContext.PhysicalEvents.Entry(UserStatus.PhysicalEvent).Collection(x => x.Users).Query().Load();
            }
        }
    }
}
