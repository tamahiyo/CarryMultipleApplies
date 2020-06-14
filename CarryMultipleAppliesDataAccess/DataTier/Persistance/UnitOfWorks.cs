using CarryMultipleAppliesCommon.Log;
using CarryMultipleAppliesDataAccess.DataTier.Core;
using CarryMultipleAppliesDataAccess.DataTier.Core.Repositories;
using CarryMultipleAppliesDataAccess.DataTier.Persistance.Repositories;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Transactions;

namespace CarryMultipleAppliesDataAccess.DataTier.Persistance
{
    public class UnitOfWorks : IUnitOfWorks
    {
        public readonly CarryMultipleAppliesModel _context;

        public UnitOfWorks(CarryMultipleAppliesModel context)
        {
            _context = context;
        }

        public IM_AgesRepository MAges => _mAges ?? (_mAges = new M_AgesRepository(_context));
        private IM_AgesRepository _mAges;

        public IM_ChooseableDomainsRepository MChooseableDomains => _mChooseableDomains ?? (_mChooseableDomains = new M_ChooseableDomainsRepository(_context));
        private IM_ChooseableDomainsRepository _mChooseableDomains;
        public IM_EventsRepository MEvents => _mEvents ?? (_mEvents = new M_EventsRepository(_context));
        private IM_EventsRepository _mEvents;

        public IM_JobsRepository MJobs => _mJobs ?? (_mJobs = new M_JobsRepository(_context));
        private IM_JobsRepository _mJobs;

        public IM_PrefecturesRepository MPrefectures => _mPrefectures ?? (_mPrefectures = new M_PrefecturesRepository(_context));
        private IM_PrefecturesRepository _mPrefectures;

        public IM_StoreEventDisplaysRepository MStoreEventDisplays => _mStoreEventDisplays ?? (_mStoreEventDisplays = new M_StoreEventDisplaysRepository(_context));
        private IM_StoreEventDisplaysRepository _mStoreEventDisplays;

        public IM_UsersRepository MUsers => _mUsers ?? (_mUsers = new M_UsersRepository(_context));
        private IM_UsersRepository _mUsers;

        public IM_StoreEventsRepository MStoreEvents => _mStoreEvents ?? (_mStoreEvents = new M_StoreEventsRepository(_context));
        private IM_StoreEventsRepository _mStoreEvents;

        public IT_ApplyHistoriesRepository TApplyHistories => _tApplyHistories ?? (_tApplyHistories = new T_ApplyHistoriesRepository(_context));
        private IT_ApplyHistoriesRepository _tApplyHistories;

        public IT_ApplyUsersRepository TApplyUsers => _tApplyUsers ?? (_tApplyUsers = new T_ApplyUsersRepository(_context));
        private IT_ApplyUsersRepository _tApplyUsers;

        public DbContextTransaction BeginTran()
        {
            return _context.Database.BeginTransaction();
        }

        public int Complete(TransactionScope trans)
        {
            int result = Complete();
            trans.Complete();

            return 0;
        }


        public int Complete()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var errorMessages = e.EntityValidationErrors
                                    .SelectMany(x => x.ValidationErrors)
                                    .Select(x => x.ErrorMessage);
                var fullErrorMessage = string.Join("; ", errorMessages);
                var exceptionMessage = string.Concat(e.Message, fullErrorMessage);
                Logger.Write((int)LogLevel.Error, fullErrorMessage);
                Logger.Write((int)LogLevel.Error, exceptionMessage);

                throw;
            }
            catch (DbUpdateException ex)
            {
                foreach (var eve in ex.Entries)
                {
                    Logger.Write((int)LogLevel.Error, string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",eve.Entity.GetType().Name, eve.State));
                }
                if (!(ex.InnerException is System.Data.Entity.Core.UpdateException) || !(ex.InnerException.InnerException is System.Data.SqlClient.SqlException))
                    throw ex;
                var sqlException = (System.Data.SqlClient.SqlException)ex.InnerException.InnerException;
                Logger.Write((int)LogLevel.Error, ex.Message + ex.StackTrace); throw;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
