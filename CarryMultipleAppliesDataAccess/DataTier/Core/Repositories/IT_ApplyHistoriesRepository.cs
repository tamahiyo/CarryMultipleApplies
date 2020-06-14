using CarryMultipleAppliesDataAccess.DataTier.Core.Domain;
using CarryMultipleAppliesDataAccess.Models;
using System.Collections.Generic;
using System.Linq;

namespace CarryMultipleAppliesDataAccess.DataTier.Core.Repositories
{
    public interface IT_ApplyHistoriesRepository : IGenericRepository<T_ApplyHistories>
    {
        List<AppliesHistories> GetList(IQueryable<AppliesHistories> query);

        bool HasAppliesHisroyByStoreEventIdAndSerialNo(int storeEventId, string serialNo, string logonUserName);

        LastApplyUserInfo GetTAppliesHistoryByUserName(string logonUserName);

        IQueryable<AppliesHistories> GetAppliesHistoriesByUserName(string logonUserName);
    }
}
