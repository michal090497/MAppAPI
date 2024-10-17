using MApp.DataAccess.DataAccessors.EventsStatusesAccessors;
using MApp.DataAccess.DataAccessors.UsersAccessors;
using MApp.DataAccess.DataModifiers.EventsStatusesModifiers;
using MApp.DataAccess.Models.EventsStatuses;
using MAppAPI.Models.Requests.EventsStatuses;
using MAppAPI.Validators.EventsStatusesValidators;

namespace MAppAPI.ControllersServices.EventsStatusesServices
{
    public class EventStatusCommentsService
    {
        StatusCommentModifier commentModifier;
        EventStatusAccessor eventStatusAccessor;
        UserAccessor userAccessor;
        UserAttendanceValidator userAttendanceValidator;
        public EventStatusCommentsService(StatusCommentModifier commentModifier, EventStatusAccessor eventStatusAccessor, UserAccessor userAccessor, UserAttendanceValidator userAttendanceValidator)
        {
            this.commentModifier = commentModifier;
            this.eventStatusAccessor = eventStatusAccessor;
            this.userAccessor = userAccessor;
            this.userAttendanceValidator = userAttendanceValidator;
        }
        public async Task<EventStatus> TryAddCommentAsync(AddCommentToStatusRequest createCommentRequest, int userID)
        {
            await userAccessor.FindEntity(userID);
            if (userAccessor.User == null)
                return null;
            await eventStatusAccessor.FindEntityWithAllDetailedAssocs(createCommentRequest.StatusID);
            if (eventStatusAccessor.UserStatus == null || !userAttendanceValidator.CheckAttendance(userAccessor.User, eventStatusAccessor.UserStatus))
                return null;
            await commentModifier.Create(eventStatusAccessor.UserStatus, createCommentRequest.Content, userAccessor.User);
            return eventStatusAccessor.UserStatus;
        }
    }
}
