using CarryMultipleAppliesDataAccess.DataTier.Core.Domain;
using CarryMultipleAppliesDataAccess.DataTier.Core.Repositories;
using System.Linq;

namespace CarryMultipleAppliesDataAccess.DataTier.Persistance.Repositories
{
    class M_PrefecturesRepository : GenericRepository<M_Prefectures>, IM_PrefecturesRepository
    {
        public M_PrefecturesRepository(CarryMultipleAppliesModel context) : base(context)
        {

        }

        public CarryMultipleAppliesModel CarryMultipleAppliesContext
        {
            get { return context as CarryMultipleAppliesModel; }
        }

    }
}
