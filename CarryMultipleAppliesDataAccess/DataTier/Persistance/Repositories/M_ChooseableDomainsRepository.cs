using CarryMultipleAppliesDataAccess.DataTier.Core.Domain;
using CarryMultipleAppliesDataAccess.DataTier.Core.Repositories;

namespace CarryMultipleAppliesDataAccess.DataTier.Persistance.Repositories
{
    class M_ChooseableDomainsRepository : GenericRepository<M_ChooseableDomains>, IM_ChooseableDomainsRepository
    {
        public M_ChooseableDomainsRepository(CarryMultipleAppliesModel context) : base(context)
        {

        }

        public CarryMultipleAppliesModel CarryMultipleAppliesContext
        {
            get { return context as CarryMultipleAppliesModel; }
        }

    }
}
