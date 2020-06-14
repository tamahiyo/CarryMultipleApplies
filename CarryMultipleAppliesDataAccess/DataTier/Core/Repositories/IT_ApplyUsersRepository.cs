using CarryMultipleAppliesDataAccess.DataTier.Core.Domain;
using CarryMultipleAppliesDataAccess.Models;

namespace CarryMultipleAppliesDataAccess.DataTier.Core.Repositories
{
    public interface IT_ApplyUsersRepository : IGenericRepository<T_ApplyUsers>
    {
        LastApplyUserInfo GetTAppliesUserByUserName(string logonUserName);
    }
}
