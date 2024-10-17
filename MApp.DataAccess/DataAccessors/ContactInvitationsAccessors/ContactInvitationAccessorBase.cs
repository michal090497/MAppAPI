using MApp.DataAccess.Context;
using MApp.DataAccess.DataAccessors.AccesorsBase;
using MApp.DataAccess.Models.Users;

namespace MApp.DataAccess.DataAccessors.ContactInvitationsAccessors
{
    public abstract class ContactInvitationAccessorBase : IContactInvitationAccessor
    {
        public ContactInvitation ContactInvitation { get; protected set; }
        public MAppDbContext dbContext { get; protected set; }

        public ContactInvitationAccessorBase(MAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public abstract Task FindEntity(int entityID);
        public abstract Task FindEntityWithBasicAssocs(int entityID);
        public abstract Task FindEntityWithDetailedAssocs(int entityID);
        public abstract Task FindEntityWithAllDetailedAssocs(int entityID);
    }
}
