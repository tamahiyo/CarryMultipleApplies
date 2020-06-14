using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarryMultipleAppliesDataAccess.Models
{
    public class AppliesHistories
    {
        /// <summary>
        /// イベントID
        /// </summary>
        public int EventId { get; set; }

        /// <summary>
        /// 店舗イベントID
        /// </summary>
        public int StoreEventId { get; set; }

        /// <summary>
        /// 応募日時
        /// </summary>
        public string ApplieDateTime { get; set; }

        /// <summary>
        /// 店舗名
        /// </summary>
        public string StoreEventName { get; set; }

        /// <summary>
        /// シリアルNo
        /// </summary>
        public string SerialNo { get; set; }

        /// <summary>
        /// 応募状況
        /// </summary>
        public int ApplieStatus { get; set; }

        /// <summary>
        /// 応募時エラーメッセージ
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// 氏名
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// 氏名ひらがな
        /// </summary>
        public string FullNameHiragana { get; set; }

        /// <summary>
        /// 年代
        /// </summary>
        public string Age { get; set; }

        /// <summary>
        /// 職業
        /// </summary>
        public string Job { get; set; }

        /// <summary>
        /// 性別
        /// </summary>
        public int Sex { get; set; }

        /// <summary>
        /// 住所
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 電話番号
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// メールアドレス
        /// </summary>
        public string MailAddress { get; set; }

    }
}
