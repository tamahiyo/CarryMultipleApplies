using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CarryMultipleAppliesService.Models
{
    public class RequestAppliesModel
    {

        public RequestAppliesModel()
        {
            AppliesStoreList = new List<AppliesStore>();
        }

        public List<AppliesStore> AppliesStoreList { get; set; }

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

        // 年代ID
        public int? AgeId { get; set; }

        /// <summary>
        /// 年代名
        /// </summary>
        public string AgeName { get; set; }

        /// <summary>
        /// 性別ID
        /// </summary>
        public int? SexId { get; set; }

        /// <summary>
        /// 性別名
        /// </summary>
        public string SexName { get; set; }

        /// <summary>
        /// 郵便番号
        /// </summary>
        public string Zipcode { get; set; }

        /// <summary>
        /// 都道府県ID
        /// </summary>
        public int? PrefectureId { get; set; }

        /// <summary>
        /// 都道府県名
        /// </summary>
        public string PrefectureName { get; set; }

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
        public int? JobId { get; set; }

        /// <summary>
        /// 職業名
        /// </summary>
        public string JobName { get; set; }

        /// <summary>
        /// メールアドレス
        /// </summary>
        public string MailAddress { get; set; }

        /// <summary>
        /// 確認画面停止フラグ
        /// </summary>
        public bool IsConfirmStop { get; set; }

        /// <summary>
        /// 店舗別申込情報
        /// </summary>
        public class AppliesStore
        {

            public AppliesStore()
            {
                SerialNoList = new List<string>();
            }

            /// <summary>
            /// 店舗イベントID
            /// </summary>
            public int StoreEventId { get; set; }

            /// <summary>
            /// 店舗イベント名
            /// </summary>
            public string StoreEventName { get; set; }

            /// <summary>
            /// 応募先URL
            /// </summary>
            public string AppliesUrl { get; set; }

            /// <summary>
            /// イベント日時
            /// </summary>
            public string EventDateTime { get; set; }

            /// <summary>
            /// シリアルNo
            /// </summary>
            public List<string> SerialNoList { get; set; }
        }

        // エラーメッセージ保持用
        public List<string> Errors = new List<string>();

        /// <summary>
        /// シリアルNoのValidate
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string SerialNoValdate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                Errors.Add(string.Format(Resource.InputRequired, "シリアルNo"));
            }
            else if(!Regex.IsMatch(value, @"^[0-9a-zA-Z]{4}-[0-9a-zA-Z]{4}-[0-9a-zA-Z]{4}-[0-9a-zA-Z]{4}$"))
            {
                Errors.Add(string.Format(Resource.InputType, "シリアルNo"));
            }
            return value;
        }

        /// <summary>
        /// テキスト形式のValidate
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <param name="IsRequired"></param>
        /// <returns></returns>
        public string StringValidate(string type, string value, bool IsRequired = false)
        {

            if (IsRequired && string.IsNullOrWhiteSpace(value))
            {
                Errors.Add(string.Format(Resource.InputRequired, type));
            }
            else if(value?.Length > 255)
            {
                Errors.Add(string.Format(Resource.InputMaxLength, type, 255));
            }

            return value;

        }

        /// <summary>
        /// ComboboxのValidate
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <param name="IsRequired"></param>
        /// <returns></returns>
        public int? ComboAndRadioValidate(string type, int? value, bool IsRequired = false)
        {
            if (IsRequired && !value.HasValue)
            {
                Errors.Add(string.Format(Resource.InputRequired, type));
            }

            return value;
        }

        /// <summary>
        /// 郵便番号のValidate
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string ZipcodeValidate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                Errors.Add(string.Format(Resource.InputRequired, "郵便番号"));
            }
            else
            {
                if (value?.Length > 8)
                {
                    Errors.Add(string.Format(Resource.InputMaxLength, "郵便番号", 8));
                }
                else if (!Regex.IsMatch(value, @"^[0-9]{7}$") && !Regex.IsMatch(value, @"^[0-9]{3}-[0-9]{4}$"))
                {
                    Errors.Add(string.Format(Resource.InputType, "郵便番号"));
                }
            }
            return value;
        }

        /// <summary>
        /// 電話番号のValidate
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string PhoneNumberValidate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                Errors.Add(string.Format(Resource.InputRequired, "電話番号"));
            }
            else
            {
                if (value?.Length > 64)
                {
                    Errors.Add(string.Format(Resource.InputMaxLength, "電話番号", 64));
                }
                else if(!Regex.IsMatch(value, @"^0\d{1,4}-\d{1,4}-\d{4}$"))
                {
                    Errors.Add(string.Format(Resource.InputType, "電話番号"));
                }
            }
            return value;

        }

        /// <summary>
        /// メールアドレスのValidate
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string MaillAddressValidate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                Errors.Add(string.Format(Resource.InputRequired, "メールアドレス"));
            }
            else
            {
                if (value?.Length > 510)
                {
                    Errors.Add(string.Format(Resource.InputMaxLength, "メールアドレス", 510));
                }
                else if (!Regex.IsMatch(value, @"[\w.\-]+@[\w\-]+\.[\w.\-]+"))
                {
                    Errors.Add(string.Format(Resource.InputType, "メールアドレス"));
                }
            }

            return value;
        }
    }
}
