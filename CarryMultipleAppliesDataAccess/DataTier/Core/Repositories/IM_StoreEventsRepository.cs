using CarryMultipleAppliesDataAccess.DataTier.Core.Domain;
using System.Collections.Generic;

namespace CarryMultipleAppliesDataAccess.DataTier.Core.Repositories
{
    public interface IM_StoreEventsRepository : IGenericRepository<M_StoreEvents>
    {
        List<M_StoreEvents> GetMStoreEventsByEventId(int eventId);

    }
}
