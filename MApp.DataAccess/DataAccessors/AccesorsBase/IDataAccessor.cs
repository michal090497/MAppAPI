using MApp.DataAccess.Context;

namespace MApp.DataAccess.DataAccessors.AccesorsBase
{
    public interface IDataAccessor
    {
        public MAppDbContext dbContext { get; }
        public abstract Task FindEntity(int entityID);
        public abstract Task FindEntityWithBasicAssocs(int entityID);
        public abstract Task FindEntityWithDetailedAssocs(int entityID);
        public abstract Task FindEntityWithAllDetailedAssocs(int entityID);
    }
}
