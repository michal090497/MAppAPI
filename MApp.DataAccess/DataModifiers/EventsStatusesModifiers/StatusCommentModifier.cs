using MApp.DataAccess.Context;
using MApp.DataAccess.Models.EventsStatuses;
using MApp.DataAccess.Models.Users;

namespace MApp.DataAccess.DataModifiers.EventsStatusesModifiers
{
    public class StatusCommentModifier : DataModifierBase, IEventStatusModifiersBase<EventStatus>
    {
        public StatusCommentModifier(MAppDbContext dbContext) : base(dbContext) { }
        public async Task Create(EventStatus baseEntity, string content, User user)
        {
            var newComment = new EventStatusComment
            {
                Creator = user,
                CreationTimeGMT = DateTime.UtcNow,
                Content = content,
            };
            baseEntity.Comments.Add(newComment);
            await dbContext.SaveChangesAsync();
        }
    }
}
