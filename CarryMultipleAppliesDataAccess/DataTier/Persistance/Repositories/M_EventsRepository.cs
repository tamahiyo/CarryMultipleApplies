using CarryMultipleAppliesDataAccess.DataTier.Core.Domain;
using CarryMultipleAppliesDataAccess.DataTier.Core.Repositories;
using System;
using System.Linq;

namespace CarryMultipleAppliesDataAccess.DataTier.Persistance.Repositories
{
    class M_EventsRepository : GenericRepository<M_Events>, IM_EventsRepository
    {
        public M_EventsRepository(CarryMultipleAppliesModel context) : base(context)
        {

        }

        public CarryMultipleAppliesModel CarryMultipleAppliesContext
        {
            get { return context as CarryMultipleAppliesModel; }
        }

        /// <summary>
        /// 応募できるイベントか判定
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        public bool IsAppliesEvent(int eventId)
        {
            var eventItem = Find(x => x.EventId == eventId).First();

            // LINQ式内だと、string→DateTimeのキャストができないため、一度取得しキャスト
            if (DateTime.Now >= DateTime.Parse(eventItem.ApplyFrom) && DateTime.Parse(eventItem.ApplyTo) >= DateTime.Now)
            {
                return true;
            }

            return false;
        }

    }
}
