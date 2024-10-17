using MApp.DataAccess.DataAccessors.UsersAccessors;
using MApp.DataAccess.DataModifiers.UsersModifiers;

namespace MAppAPI.ControllersServices.UsersServices
{
    public class ContactsService
    {
        UserWithContactsAccessor userWithContactsAccessor;
        ContactsModifier contactsModifier;
        public ContactsService(UserWithContactsAccessor userWithContactsAccessor, ContactsModifier contactsModifier)
        {
            this.userWithContactsAccessor = userWithContactsAccessor;
            this.contactsModifier = contactsModifier;
        }
        public async Task<string> TryDeleteContactAsync(int contactToBeDeletedUserID, int userID)
        {
            await userWithContactsAccessor.FindEntity(userID);
            var user = userWithContactsAccessor.User;
            if (user == null)
                return "user not found";
            await userWithContactsAccessor.FindEntity(contactToBeDeletedUserID);
            var contactToBeDeletedUser = userWithContactsAccessor.User;
            if (contactToBeDeletedUser == null)
                return "contact not found";
            await contactsModifier.TryDeleteContact(user, contactToBeDeletedUser);
            return "ok";
        }
    }
}
