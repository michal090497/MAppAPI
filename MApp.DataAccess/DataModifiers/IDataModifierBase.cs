using MApp.DataAccess.Context;

namespace MApp.DataAccess.DataModifiers
{
    public interface IDataModifierBase
    {
        public MAppDbContext dbContext { get; }
    }
}
