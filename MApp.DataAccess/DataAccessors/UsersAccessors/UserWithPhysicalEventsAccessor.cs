using MApp.DataAccess.Context;
using MApp.DataAccess.DataAccessors.AccesorsBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MApp.DataAccess.DataAccessors.UsersAccessors
{
    public class UserWithPhysicalEventsAccessor : UserAccessorBase, IUserAccessor
    {
        public UserWithPhysicalEventsAccessor(MAppDbContext dbContext) : base(dbContext) { }
        public async override Task FindEntity(int entityID)
        {
            User = await dbContext.AllUsers.Include(x => x.PhysicalEvents)
                .Include(x => x.AttendedPhysicalEvents).FirstOrDefaultAsync(x => x.ID == entityID);
        }
        public async override Task FindEntityWithBasicAssocs(int entityID) => await FindEntity(entityID);
        public async override Task FindEntityWithDetailedAssocs(int entityID) => await FindEntityWithBasicAssocs(entityID);
        public async override Task FindEntityWithAllDetailedAssocs(int entityID) => await FindEntityWithDetailedAssocs(entityID);
    }
}
