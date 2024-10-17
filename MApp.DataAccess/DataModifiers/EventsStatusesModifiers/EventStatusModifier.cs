using MApp.DataAccess.Context;
using MApp.DataAccess.Models.EventsBase;
using MApp.DataAccess.Models.EventsStatuses;
using MApp.DataAccess.Models.Users;

namespace MApp.DataAccess.DataModifiers.EventsStatusesModifiers
{
    public class EventStatusModifier : DataModifierBase, IEventStatusModifiersBase<IEventBase>
    {
        public EventStatusModifier(MAppDbContext dbContext) : base(dbContext) { }
        public async Task Create(IEventBase baseEntity, string content, User user)
        {
            var newStatus = new EventStatus
            {
                Creator = user,
                CreationTimeGMT = DateTime.UtcNow,
                Content = content,
            };
            baseEntity.Statuses.Add(newStatus);
            await dbContext.SaveChangesAsync();
        }
    }
}
