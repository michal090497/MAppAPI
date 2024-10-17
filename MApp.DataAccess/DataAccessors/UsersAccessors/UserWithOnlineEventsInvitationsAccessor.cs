using MApp.DataAccess.Context;
using MApp.DataAccess.DataAccessors.AccesorsBase;
using Microsoft.EntityFrameworkCore;

namespace MApp.DataAccess.DataAccessors.UsersAccessors
{
    public class UserWithOnlineEventsInvitationsAccessor : UserAccessorBase, IUserAccessor
    {
        public UserWithOnlineEventsInvitationsAccessor(MAppDbContext dbContext) : base(dbContext) { }
        public async override Task FindEntity(int entityID)
        {
            User = await dbContext.AllUsers.Include(x => x.OnlineEventsInvitations).FirstOrDefaultAsync(x => x.ID == entityID);
        }
        public async override Task FindEntityWithBasicAssocs(int entityID)
        {
            User = await dbContext.AllUsers.Include(x => x.OnlineEventsInvitations).ThenInclude(x => x.Event).FirstOrDefaultAsync(x => x.ID == entityID);
        }
        public async override Task FindEntityWithDetailedAssocs(int entityID)
        {
            User = await dbContext.AllUsers.Include(x => x.OnlineEventsInvitations).ThenInclude(x => x.Event).ThenInclude(x => x.Users).FirstOrDefaultAsync(x => x.ID == entityID);
        }
        public async override Task FindEntityWithAllDetailedAssocs(int entityID) => await FindEntityWithDetailedAssocs(entityID);
    }
}
