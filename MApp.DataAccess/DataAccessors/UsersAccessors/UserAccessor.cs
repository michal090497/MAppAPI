using MApp.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace MApp.DataAccess.DataAccessors.UsersAccessors
{
    public class UserAccessor : UserAccessorBase
    {
        public UserAccessor(MAppDbContext dbContext) : base(dbContext) { }
        public async override Task FindEntity(int entityID)
        {
            User = await dbContext.AllUsers.FirstOrDefaultAsync(x => x.ID == entityID);
        }
        public async override Task FindEntityWithBasicAssocs(int entityID)
        {
            User = await dbContext.AllUsers.Include(x => x.Contacts).Include(x => x.Invitations).Include(x => x.FavouriteOnlineEventCategories).Include(x => x.FavouritePhysicalEventCategories).FirstOrDefaultAsync(x => x.ID == entityID);
        }
        public async override Task FindEntityWithDetailedAssocs(int entityID) => await FindEntityWithBasicAssocs(entityID);
        public async override Task FindEntityWithAllDetailedAssocs(int entityID) => await FindEntityWithDetailedAssocs(entityID);
        public async Task GetLoggedUser(int entityID)
        {
            User = await dbContext.AllUsers.Include(x => x.AttendedOnlineEvents).Include(x => x.AttendedOnlineEvents).Include(x => x.OnlineEvents).Include(x => x.PhysicalEvents)
                .Include(x => x.OnlineEventsInvitations).ThenInclude(x => x.Event).Include(x => x.PhysicalEventsInvitations).ThenInclude(x => x.Event)
                .Include(x => x.FavouriteOnlineEventCategories).Include(x => x.FavouritePhysicalEventCategories).Include(x => x.Contacts).Include(x => x.Invitations)
                .FirstOrDefaultAsync(x => x.ID == entityID);
        }
    }
}
