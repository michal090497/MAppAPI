using MApp.DataAccess.Context;
using MApp.DataAccess.DataAccessors.AccesorsBase;
using Microsoft.EntityFrameworkCore;

namespace MApp.DataAccess.DataAccessors.UsersAccessors
{
    public class UserWithPhysicalEventsInvitationsAccessor : UserAccessorBase, IUserAccessor
    {
        public UserWithPhysicalEventsInvitationsAccessor(MAppDbContext dbContext) : base(dbContext) { }
        public async override Task FindEntity(int entityID)
        {
            User = await dbContext.AllUsers.Include(x => x.PhysicalEventsInvitations).FirstOrDefaultAsync(x => x.ID == entityID);
        }
        public async override Task FindEntityWithBasicAssocs(int entityID) => await FindEntity(entityID);
        public async override Task FindEntityWithDetailedAssocs(int entityID) => await FindEntityWithBasicAssocs(entityID);
        public async override Task FindEntityWithAllDetailedAssocs(int entityID) => await FindEntityWithDetailedAssocs(entityID);
    }
}
