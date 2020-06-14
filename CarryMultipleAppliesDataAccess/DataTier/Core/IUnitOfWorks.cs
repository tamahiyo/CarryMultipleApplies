using CarryMultipleAppliesDataAccess.DataTier.Core.Repositories;
using System;
using System.Data.Entity;
using System.Transactions;

namespace CarryMultipleAppliesDataAccess.DataTier.Core
{
    public interface IUnitOfWorks : IDisposable
    {
        IM_AgesRepository MAges { get; }

        IM_ChooseableDomainsRepository MChooseableDomains { get; }

        IM_EventsRepository MEvents { get; }

        IM_JobsRepository MJobs { get; }

        IM_PrefecturesRepository MPrefectures { get; }

        IM_StoreEventDisplaysRepository MStoreEventDisplays { get; }

        IM_StoreEventsRepository MStoreEvents { get; }

        IM_UsersRepository MUsers { get; }

        IT_ApplyHistoriesRepository TApplyHistories { get; }

        IT_ApplyUsersRepository TApplyUsers { get; }        

        DbContextTransaction BeginTran();

        int Complete(TransactionScope trans);

        int Complete();
    }
}
