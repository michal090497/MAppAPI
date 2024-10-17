using MApp.DataAccess.Context;
using MApp.DataAccess.DataAccessors.AccesorsBase;
using Microsoft.EntityFrameworkCore;

namespace MApp.DataAccess.DataAccessors.UsersAccessors
{
    public class UserWithContactsAccessor : UserAccessorBase, IUserAccessor
    {
        public UserWithContactsAccessor(MAppDbContext dbContext) : base(dbContext) { }
        public async override Task FindEntity(int entityID)
        {
            User = await dbContext.AllUsers.Include(x => x.Contacts).FirstOrDefaultAsync(x => x.ID == entityID);
        }
        public async override Task FindEntityWithBasicAssocs(int entityID)
        {
            User = await dbContext.AllUsers.Include(x => x.Contacts).ThenInclude(x => x.Contacts).FirstOrDefaultAsync(x => x.ID == entityID);
        }
        public async override Task FindEntityWithDetailedAssocs(int entityID) => await FindEntityWithBasicAssocs(entityID);
        public async override Task FindEntityWithAllDetailedAssocs(int entityID) => await FindEntityWithDetailedAssocs(entityID);

    }
}
