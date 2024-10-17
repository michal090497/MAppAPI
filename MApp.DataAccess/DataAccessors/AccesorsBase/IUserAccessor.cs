using MApp.DataAccess.Models.Users;

namespace MApp.DataAccess.DataAccessors.AccesorsBase
{
    public interface IUserAccessor : IDataAccessor
    {
        public User User { get; }

    }
}
