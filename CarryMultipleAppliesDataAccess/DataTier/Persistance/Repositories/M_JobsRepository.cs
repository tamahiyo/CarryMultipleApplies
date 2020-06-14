using CarryMultipleAppliesDataAccess.DataTier.Core.Domain;
using CarryMultipleAppliesDataAccess.DataTier.Core.Repositories;

namespace CarryMultipleAppliesDataAccess.DataTier.Persistance.Repositories
{
    class M_JobsRepository : GenericRepository<M_Jobs>, IM_JobsRepository
    {
        public M_JobsRepository(CarryMultipleAppliesModel context) : base(context)
        {

        }

        public CarryMultipleAppliesModel CarryMultipleAppliesContext
        {
            get { return context as CarryMultipleAppliesModel; }
        }

    }
}
