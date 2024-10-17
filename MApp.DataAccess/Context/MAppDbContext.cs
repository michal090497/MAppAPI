using MApp.DataAccess.Models.EventsStatuses;
using MApp.DataAccess.Models.OnlineEvents;
using MApp.DataAccess.Models.PhysicalEvents;
using MApp.DataAccess.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace MApp.DataAccess.Context;

public class MAppDbContext : DbContext
{
    public DbSet<User> AllUsers { get; set; }
    public DbSet<ContactInvitation> ContactInvitations { get; set; }
    //public DbSet<Conversation> conversations { get; set; }
    //public DbSet<ConversationMessage> messages { get; set; }
    public DbSet<OnlineEventCategory> OnlineEventCategories { get; set; }
    public DbSet<OnlineEvent> OnlineEvents { get; set; }
    public DbSet<OnlineEventAttendee> OnlineEventAttendees { get; set; }
    public DbSet<OnlineEventDetails> OnlineEventsDetails { get; set; }
    public DbSet<OnlineEventInvitation> OnlineEventsInvitations { get; set; }
    public DbSet<PhysicalEventCategory> PhysicalEventCategories { get; set; }
    public DbSet<PhysicalEvent> PhysicalEvents { get; set; }
    public DbSet<PhysicalEventAttendee> PhysicalEventAttendees { get; set; }
    public DbSet<PhysicalEventDetails> PhysicalEventsDetails { get; set; }
    public DbSet<PhysicalEventInvitation> PhysicalEventsInvitations { get; set; }
    public DbSet<OnlineEventArchived> OnlineEventsArchived { get; set; }
    public DbSet<PhysicalEventArchived> PhysicalEventsArchived { get; set; }
    public DbSet<EventStatus> EventsStatuses { get; set; }
    public DbSet<EventStatusComment> EventsStatusesComments { get; set; }

    public MAppDbContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Database=MApp;Username=postgres;Password=temp");
    }

    public static async void ArchiveEvents(MAppDbContext databaseConnectionProvider)
    {
        //PhysicalEventsService.ArchivePhysicalEvents(databaseConnectionProvider);
        //OnlineEventsService.ArchiveOnlineEvents(databaseConnectionProvider);
        await Task.Delay(10000);
        ArchiveEvents(databaseConnectionProvider);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany(e => e.Contacts)
            .WithMany();
        modelBuilder.Entity<OnlineEvent>()
            .HasMany(x => x.Statuses).WithOne(y => y.OnlineEvent).IsRequired(false);
        modelBuilder.Entity<PhysicalEvent>()
            .HasMany(x => x.Statuses).WithOne(y => y.PhysicalEvent).IsRequired(false);
        modelBuilder.Entity<EventStatus>()
            .HasMany(x => x.Comments).WithOne(y => y.Status);
        modelBuilder.Entity<OnlineEvent>()
            .HasMany(x => x.Users).WithMany(x => x.OnlineEvents).UsingEntity<OnlineEventAttendee>();
        modelBuilder.Entity<PhysicalEvent>()
            .HasMany(x => x.Users).WithMany(x => x.PhysicalEvents).UsingEntity<PhysicalEventAttendee>();
    }
    /*
        public static void ArchiveOnlineEvents(MAppDbContext dbContext)
        {
            var time = DateTime.Now.ToUniversalTime();
            var onlineEvents = dbContext.onlineEvents.Include(x => x.users).Include(x => x.category).Include(x => x.details).Where(x => x.eventDate < time).ToList();
            foreach (var onlineEvent in onlineEvents)
            {
                var tempEvent = new OnlineEventArchived
                {
                    eventDate = onlineEvent.eventDate,
                    //eventDateGMT = onlineEvent.eventDateGMT,
                    eventTitle = onlineEvent.eventTitle,
                    eventDescription = onlineEvent.eventDescription,
                    spotsLeft = onlineEvent.spotsLeft,
                    categoryName = onlineEvent.category.onlineEventCategoryName,
                    subcategory = onlineEvent.subcategory,
                    creatorID = onlineEvent.creatorID,
                    onlineEventsID = onlineEvent.onlineEventsID,
                    //users = PhysicalEventArchived.ConvertUsers(onlineEvent.users.ToList()),
                    details = onlineEvent.details.details,
                    wayOfContact = onlineEvent.details.wayOfContact,
                    contactDetails = onlineEvent.details.contactDetails,
                };
                var onlineEventDetails = onlineEvent.details;
                //var onlineEventDetails = databaseConnectionProvider.onlineEventsDetails.Where(x => x.onlineEventDetailsID == onlineEvent.onlineEventsID).FirstOrDefault();
                dbContext.onlineEventsArchived.Add(tempEvent);
                dbContext.onlineEvents.Remove(onlineEvent);
                if(onlineEventDetails != null)
                    dbContext.onlineEventsDetails.Remove(onlineEventDetails);
                dbContext.SaveChanges();
            }
        }

        public static void ArchivePhysicalEvents(DatabaseConnectionProvider databaseConnectionProvider)
        {
            var time = DateTime.Now.ToUniversalTime();
            var physicalEvents = databaseConnectionProvider.physicalEvents.Include(x => x.users).Include(x => x.category).Include(x => x.details).Where(x => x.eventDateGMT < time).ToList();
            foreach (var physicalEvent in physicalEvents)
            {
                var tempEvent = new PhysicalEventArchived
                {
                    eventDate = physicalEvent.eventDate,
                    eventDateGMT = physicalEvent.eventDateGMT,
                    eventTitle = physicalEvent.eventTitle,
                    eventDescription = physicalEvent.eventDescription,
                    longtitude = physicalEvent.longtitude,
                    latitude = physicalEvent.latitude,
                    spotsLeft = physicalEvent.spotsLeft,
                    categoryName = physicalEvent.category.physicalEventCategoryName,
                    subcategory = physicalEvent.subcategory,
                    creatorID = physicalEvent.creatorID,
                    physicalEventsID = physicalEvent.physicalEventsID,
                    users = PhysicalEventArchived.ConvertUsers(physicalEvent.users.ToList()),
                    details = physicalEvent.details.details,
                    wayOfContact = physicalEvent.details.wayOfContact,
                    contactDetails = physicalEvent.details.contactDetails,
                    howToGetThereInfo = physicalEvent.details.howToGetThereInfo
                };
                var physicalEventDetails = physicalEvent.details;
                databaseConnectionProvider.physicalEventsArchived.Add(tempEvent);
                databaseConnectionProvider.physicalEvents.Remove(physicalEvent);
                if (physicalEventDetails != null)
                    databaseConnectionProvider.physicalEventsDetails.Remove(physicalEventDetails);
                databaseConnectionProvider.SaveChanges();
            }
        }

     */
}
