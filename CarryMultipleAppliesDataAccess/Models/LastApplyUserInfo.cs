
namespace CarryMultipleAppliesDataAccess.Models
{
    public class LastApplyUserInfo
    {
        /// <summary>
        /// 姓
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// 名
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// 姓ひらがな
        /// </summary>
        public string LastNameHiragana { get; set; }

        /// <summary>
        /// 名ひらがな
        /// </summary>
        public string FirstNameHiragana { get; set; }

        /// <summary>
        /// 年代ID
        /// </summary>
        public int AgeId { get; set; }

        /// <summary>
        /// 性別
        /// </summary>
        public int Sex { get; set; }

        /// <summary>
        /// 郵便番号
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// 都道府県ID
        /// </summary>
        public int PrefectureId { get; set; }

        /// <summary>
        /// 市区町村
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 町名・番地
        /// </summary>
        public string StreetBunchName { get; set; }

        /// <summary>
        /// 建物・マンション名
        /// </summary>
        public string BuildingName { get; set; }

        /// <summary>
        /// 電話番号
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 職業ID
        /// </summary>
        public int JobId { get; set; }

        /// <summary>
        /// メールアドレス
        /// </summary>
        public string MailAddress { get; set; }

    }
}
