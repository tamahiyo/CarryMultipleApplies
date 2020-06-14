using CarryMultipleAppliesDataAccess.DataTier.Core.Domain;
using CarryMultipleAppliesDataAccess.DataTier.Core.Repositories;

namespace CarryMultipleAppliesDataAccess.DataTier.Persistance.Repositories
{
    class M_UsersRepository : GenericRepository<M_Users>, IM_UsersRepository
    {
        public M_UsersRepository(CarryMultipleAppliesModel context) : base(context)
        {

        }

        public CarryMultipleAppliesModel CarryMultipleAppliesContext
        {
            get { return context as CarryMultipleAppliesModel; }
        }

    }
}
