using MApp.DataAccess.Context;
using MApp.DataAccess.DataAccessors.AccesorsBase;
using MApp.DataAccess.Models.Users;

namespace MApp.DataAccess.DataAccessors.UsersAccessors
{
    public abstract class UserAccessorBase : IUserAccessor
    {
        public User User { get; protected set; }
        public MAppDbContext dbContext { get; protected set; }
        public UserAccessorBase(MAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public abstract Task FindEntity(int entityID);
        public abstract Task FindEntityWithBasicAssocs(int entityID);
        public abstract Task FindEntityWithDetailedAssocs(int entityID);
        public abstract Task FindEntityWithAllDetailedAssocs(int entityID);
    }
}
