using MApp.DataAccess.DataAccessors.AccesorsBase;
using MApp.DataAccess.DataAccessors.UsersAccessors;
using MApp.DataAccess.Models.EventsBase;

namespace MAppAPI.ControllersServices.EventsServicesBase
{
    public interface IEventInfoServiceBase<EventAccessorType, EvemtType>
        where EventAccessorType : IEventsAccesor<EvemtType>
        where EvemtType : IEventBase
    {
        UserAccessor userAccessor { get; }
    }
}
