using MApp.DataAccess.Context;

namespace MApp.DataAccess.DataModifiers
{
    public abstract class DataModifierBase : IDataModifierBase
    {
        public MAppDbContext dbContext { get; protected set; }
        public DataModifierBase(MAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
