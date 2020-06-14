using CarryMultipleAppliesDataAccess.DataTier.Core.Domain;
using CarryMultipleAppliesDataAccess.DataTier.Core.Repositories;

namespace CarryMultipleAppliesDataAccess.DataTier.Persistance.Repositories
{
    class M_AgesRepository : GenericRepository<M_Ages>, IM_AgesRepository
    {
        public M_AgesRepository(CarryMultipleAppliesModel context) : base(context)
        {

        }

        public CarryMultipleAppliesModel CarryMultipleAppliesContext
        {
            get { return context as CarryMultipleAppliesModel; }
        }

    }
}
