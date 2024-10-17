namespace MApp.DataAccess.Models.Users;

public interface IUser : IEntityBase
{
    string Username { get; }
    string EncryptedPassword { get; }
    string EMail { get; }
}
