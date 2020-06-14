using CarryMultipleAppliesDataAccess.DataTier.Core.Domain;
using CarryMultipleAppliesDataAccess.DataTier.Core.Repositories;

namespace CarryMultipleAppliesDataAccess.DataTier.Persistance.Repositories
{
    class M_StoreEventDisplaysRepository : GenericRepository<M_StoreEventDisplays>, IM_StoreEventDisplaysRepository
    {
        public M_StoreEventDisplaysRepository(CarryMultipleAppliesModel context) : base(context)
        {

        }

        public CarryMultipleAppliesModel CarryMultipleAppliesContext
        {
            get { return context as CarryMultipleAppliesModel; }
        }

    }
}
