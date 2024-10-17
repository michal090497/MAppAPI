using MApp.DataAccess.Context;
using MApp.DataAccess.DataAccessors.AccesorsBase;
using Microsoft.EntityFrameworkCore;

namespace MApp.DataAccess.DataAccessors.UsersAccessors
{
    public class UserWithOnlineEventsAccessor : UserAccessorBase, IUserAccessor
    {
        public UserWithOnlineEventsAccessor(MAppDbContext dbContext) : base(dbContext) { }
        public override async Task FindEntity(int entityID)
        {
            User = await dbContext.AllUsers.Include(x => x.OnlineEvents)
                .Include(x => x.AttendedOnlineEvents).FirstOrDefaultAsync(x => x.ID == entityID);
        }
        public async override Task FindEntityWithBasicAssocs(int entityID) => await FindEntity(entityID);
        public async override Task FindEntityWithDetailedAssocs(int entityID) => await FindEntityWithBasicAssocs(entityID);
        public async override Task FindEntityWithAllDetailedAssocs(int entityID) => await FindEntityWithDetailedAssocs(entityID);
    }
}
