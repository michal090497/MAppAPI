using MApp.DataAccess.Context;
using MApp.DataAccess.Models.Users;

namespace MApp.DataAccess.DataModifiers.UsersModifiers
{
    public class ContactsModifier : DataModifierBase
    {
        public ContactsModifier(MAppDbContext dbContext) : base(dbContext) { }
        public async Task TryDeleteContact(User user, User contactToBeDeleted)
        {
            if (user.Contacts.Any(x => x == contactToBeDeleted))
            {
                user.Contacts.Remove(contactToBeDeleted);
                contactToBeDeleted.Contacts.Remove(user);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
