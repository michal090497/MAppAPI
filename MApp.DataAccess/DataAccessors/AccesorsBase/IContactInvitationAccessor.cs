using MApp.DataAccess.Models.Users;

namespace MApp.DataAccess.DataAccessors.AccesorsBase
{
    public interface IContactInvitationAccessor : IDataAccessor
    {
        public ContactInvitation ContactInvitation { get; }
    }
}
