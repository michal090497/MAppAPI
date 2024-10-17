using MApp.DataAccess.Models.EventsStatuses;
using MApp.DataAccess.Models.Users;

namespace MAppAPI.Validators.EventsStatusesValidators
{
    public class UserAttendanceValidator
    {
        public UserAttendanceValidator() { }
        public bool CheckAttendance(User user, EventStatus userStatus)
        {
            if(userStatus.OnlineEvent != null)
                return userStatus.OnlineEvent.Users.Any(x => x == user);
            else if (userStatus.PhysicalEvent != null)
                return userStatus.PhysicalEvent.Users.Any(x => x == user);
            else return false;
        }
    }
}
