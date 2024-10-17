namespace MApp.DataAccess.DataModifiers.EventsModifiersBase
{
    public interface IEventCreatorBase : IDataModifierBase
    {
        public async Task<bool> CreateDbObject() { return false; }
    }
}
