using MApp.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace MApp.DataAccess.DataAccessors.ContactInvitationsAccessors
{
    public class ContactInvitationAccessor : ContactInvitationAccessorBase
    {
        public ContactInvitationAccessor(MAppDbContext dbContext) : base(dbContext) { }
        public async override Task FindEntity(int entityID)
        {
            ContactInvitation = await dbContext.ContactInvitations
                .FirstOrDefaultAsync(x => x.ID == entityID);
        }
        public async override Task FindEntityWithBasicAssocs(int entityID)
        {
            ContactInvitation = await dbContext.ContactInvitations
                .Include(x => x.InvitedUser)
                .FirstOrDefaultAsync(x => x.ID == entityID);
        }
        public async override Task FindEntityWithDetailedAssocs(int entityID)
        {
            ContactInvitation = await dbContext.ContactInvitations
                .Include(x => x.InvitedUser).ThenInclude(x => x.Contacts)
                .FirstOrDefaultAsync(x => x.ID == entityID);
        }
        public async override Task FindEntityWithAllDetailedAssocs(int entityID) => await FindEntityWithDetailedAssocs(entityID);
    }
}
