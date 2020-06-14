using CarryMultipleAppliesDataAccess.DataTier.Core.Domain;
using CarryMultipleAppliesDataAccess.DataTier.Core.Repositories;
using CarryMultipleAppliesDataAccess.Models;
using System.Linq;

namespace CarryMultipleAppliesDataAccess.DataTier.Persistance.Repositories
{
    class T_ApplyUsersRepository : GenericRepository<T_ApplyUsers>, IT_ApplyUsersRepository
    {
        public T_ApplyUsersRepository(CarryMultipleAppliesModel context) : base(context)
        {

        }

        public CarryMultipleAppliesModel CarryMultipleAppliesContext
        {
            get { return context as CarryMultipleAppliesModel; }
        }

        /// <summary>
        /// ユーザー名より、最新のユーザー情報の取得
        /// </summary>
        /// <param name="logonUserName"></param>
        /// <returns></returns>
        public LastApplyUserInfo GetTAppliesUserByUserName(string logonUserName)
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

    }
}
