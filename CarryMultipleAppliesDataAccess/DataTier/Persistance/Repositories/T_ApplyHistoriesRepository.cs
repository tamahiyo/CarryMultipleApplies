using CarryMultipleAppliesDataAccess.DataTier.Core.Domain;
using CarryMultipleAppliesDataAccess.DataTier.Core.Repositories;
using CarryMultipleAppliesDataAccess.Models;
using System.Collections.Generic;
using System.Linq;

namespace CarryMultipleAppliesDataAccess.DataTier.Persistance.Repositories
{
    class T_ApplyHistoriesRepository : GenericRepository<T_ApplyHistories>, IT_ApplyHistoriesRepository
    {
        public T_ApplyHistoriesRepository(CarryMultipleAppliesModel context) : base(context)
        {

        }

        public CarryMultipleAppliesModel CarryMultipleAppliesContext
        {
            get { return context as CarryMultipleAppliesModel; }
        }

        /// <summary>
        /// 動的クエリの結果レコード返却
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public List<AppliesHistories> GetList(IQueryable<AppliesHistories> query)
        {
            return query.ToList();
        }

        /// <summary>
        /// 引数より、応募履歴の存在チェック
        /// </summary>
        /// <param name="storeEventId"></param>
        /// <param name="serialNo"></param>
        /// <param name="logonUserName"></param>
        /// <returns></returns>
        public bool HasAppliesHisroyByStoreEventIdAndSerialNo(int storeEventId, string serialNo, string logonUserName)
        {
            return Find(x => x.StoreEventId == storeEventId && x.SerialNo == serialNo && x.UserName == logonUserName).Any();
        }

        /// <summary>
        /// ユーザー名より、最新の応募履歴の取得
        /// </summary>
        /// <param name="logonUserName"></param>
        /// <returns></returns>
        public LastApplyUserInfo GetTAppliesHistoryByUserName(string logonUserName)
        {
            return Find(x => x.UserName == logonUserName)
                    .Select(s => new LastApplyUserInfo()
                    {
                        LastName = s.LastName,
                        FirstName = s.FirstName,
                        LastNameHiragana = s.LastNameHiragana,
                        FirstNameHiragana = s.FirstNameHiragana,
                        AgeId = s.AgeId,
                        Sex = s.Sex,
                        ZipCode = s.Zipcode,
                        PrefectureId = s.PrefectureId,
                        City = s.City,
                        StreetBunchName = s.StreetBunchName,
                        BuildingName = s.BuildingName,
                        PhoneNumber = s.PhoneNumber,
                        JobId = s.JobId,
                        MailAddress = s.MailAddress
                    })
                    .LastOrDefault();
        }

        /// <summary>
        /// ユーザー名に紐づく、応募履歴の取得クエリ
        /// </summary>
        /// <param name="logonUserName"></param>
        /// <returns></returns>
        public IQueryable<AppliesHistories> GetAppliesHistoriesByUserName(string logonUserName)
        {

            return from appliesHistory in context.TApplyHistories
                   join storeEvents in context.MStoreEvents
                   on appliesHistory.StoreEventId equals storeEvents.StoreEventId
                   join ages in context.MAges
                        on appliesHistory.AgeId equals ages.AgeId
                   join jobs in context.MJobs
                   on appliesHistory.JobId equals jobs.JobId
                   join prefectures in context.MPrefectures
                   on appliesHistory.PrefectureId equals prefectures.PrefectureId
                   where appliesHistory.UserName == logonUserName
                   orderby appliesHistory.InsertDate descending
                   select new AppliesHistories
                   {
                       ApplieDateTime = appliesHistory.InsertDate,
                       StoreEventName = storeEvents.StoreEventName,
                       SerialNo = appliesHistory.SerialNo,
                       ApplieStatus = appliesHistory.AppliesStatusType,
                       ErrorMessage = appliesHistory.AppliesStatusMessage,
                       FullName = appliesHistory.LastName + appliesHistory.FirstName,
                       FullNameHiragana = appliesHistory.LastNameHiragana + appliesHistory.FirstNameHiragana,
                       Age = ages.AgeName,
                       Job = jobs.JobName,
                       Sex = appliesHistory.Sex,
                       Address = appliesHistory.Zipcode.ToString() + prefectures.PrefectureName + appliesHistory.City + appliesHistory.StreetBunchName + appliesHistory.BuildingName,
                       PhoneNumber = appliesHistory.PhoneNumber,
                       MailAddress = appliesHistory.MailAddress,
                   };


        }

    }
}
