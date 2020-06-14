using CarryMultipleAppliesDataAccess.DataTier.Core.Domain;

namespace CarryMultipleAppliesDataAccess.DataTier.Core.Repositories
{
    public interface IM_EventsRepository : IGenericRepository<M_Events>
    {
        bool IsAppliesEvent(int eventId);
    }
}
