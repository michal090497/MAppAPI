using MApp.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace MApp.DataAccess.DataAccessors.UsersAccessors
{
    public class UserWithContactInvitationsAccessor : UserAccessorBase
    {
        public UserWithContactInvitationsAccessor(MAppDbContext dbContext) : base(dbContext) { }
        public async override Task FindEntity(int entityID)
        {
            User = await dbContext.AllUsers.Include(x => x.Invitations).FirstOrDefaultAsync(x => x.ID == entityID);
        }
        public async override Task FindEntityWithBasicAssocs(int entityID)
        {
            User = await dbContext.AllUsers.Include(x => x.Invitations).Include(x => x.Contacts).FirstOrDefaultAsync(x => x.ID == entityID);
        }
        public async override Task FindEntityWithDetailedAssocs(int entityID) => await FindEntityWithBasicAssocs(entityID);
        public async override Task FindEntityWithAllDetailedAssocs(int entityID) => await FindEntityWithDetailedAssocs(entityID);
    }
}
