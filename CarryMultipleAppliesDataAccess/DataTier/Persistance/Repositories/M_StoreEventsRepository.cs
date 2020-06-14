using CarryMultipleAppliesDataAccess.DataTier.Core.Domain;
using CarryMultipleAppliesDataAccess.DataTier.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace CarryMultipleAppliesDataAccess.DataTier.Persistance.Repositories
{
    class M_StoreEventsRepository : GenericRepository<M_StoreEvents>, IM_StoreEventsRepository
    {
        public M_StoreEventsRepository(CarryMultipleAppliesModel context) : base(context)
        {

        }

        public CarryMultipleAppliesModel CarryMultipleAppliesContext
        {
            get { return context as CarryMultipleAppliesModel; }
        }

        /// <summary>
        /// イベントIDに紐づく店舗イベントの取得
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        public List<M_StoreEvents> GetMStoreEventsByEventId(int eventId)
        {
            return Find(x => x.EventId == eventId).ToList();
        }
    }
}
