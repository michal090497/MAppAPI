using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MApp.DataAccess.Models.OnlineEvents;
using MApp.DataAccess.Models.PhysicalEvents;

namespace MApp.DataAccess.Models.Users;

public class User : IUser
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; protected set; }
    public string Username { get; protected set; }
    public string EncryptedPassword { get; protected set; }
    public string EMail { get; protected set; }
    public int UserLevel { get; protected set; }
    public string Bio { get; set; }
    public string Languages { get; set; }
    public string Hobbies { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string ProfilePicturePath { get; set; }
    public virtual ICollection<PhysicalEvent> PhysicalEvents { get; set; }
    public virtual ICollection<PhysicalEventAttendee> AttendedPhysicalEvents { get; set; }
    public virtual ICollection<PhysicalEventInvitation> PhysicalEventsInvitations { get; set; }
    public virtual ICollection<OnlineEvent> OnlineEvents { get; set; }
    public virtual ICollection<OnlineEventAttendee> AttendedOnlineEvents { get; set; }
    public virtual ICollection<OnlineEventInvitation> OnlineEventsInvitations { get; set; }
    //public virtual ICollection<Conversation> conversations { get; set; }
    public virtual ICollection<User> Contacts { get; set; }
    public virtual ICollection<ContactInvitation> Invitations { get; set; }
    public virtual ICollection<OnlineEventCategory> FavouriteOnlineEventCategories { get; set; }
    public virtual ICollection<PhysicalEventCategory> FavouritePhysicalEventCategories { get; set; }

    public User(string uName, string encryptedPass, string mail, int uLevel)
        : this()
    {
        Username = uName;
        EncryptedPassword = encryptedPass;
        EMail = mail;
        UserLevel = uLevel;
        Bio = string.Empty;
        Languages = string.Empty;
        Hobbies = string.Empty;
        DateOfBirth = DateTime.MinValue;
        ProfilePicturePath = string.Empty;
    }
    private User()
    {
        PhysicalEvents = new HashSet<PhysicalEvent>();
        AttendedPhysicalEvents = new HashSet<PhysicalEventAttendee>();
        PhysicalEventsInvitations = new HashSet<PhysicalEventInvitation>();
        OnlineEvents = new HashSet<OnlineEvent>();
        AttendedOnlineEvents = new HashSet<OnlineEventAttendee>();
        OnlineEventsInvitations = new HashSet<OnlineEventInvitation>();
        //conversations = new HashSet<Conversation>();
        Contacts = new HashSet<User>();
        Invitations = new HashSet<ContactInvitation>();
        FavouriteOnlineEventCategories = new HashSet<OnlineEventCategory>();
        FavouritePhysicalEventCategories = new HashSet<PhysicalEventCategory>();
    }
    public void ChangeUserName(string username) => Username = username;
    public void ChangeEncryptedPassword(string encryptedPassword) => EncryptedPassword = encryptedPassword;
    public void ChangeMail(string eMail) => EMail = eMail;
    public void ChangeUserLevel(int userLevel) => UserLevel = userLevel;
}
