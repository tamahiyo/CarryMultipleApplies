namespace CarryMultipleAppliesDataAccess.DataTier.Core.Domain
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class T_ApplyUsers
    {
        /// <summary>
        /// 応募者情報ID
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ApplyUserId { get; set; }

        /// <summary>
        /// ログオンユーザー名
        /// </summary>
        [Required]
        [StringLength(20)]
        public string UserName { get; set; }

        /// <summary>
        /// 姓
        /// </summary>
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        /// <summary>
        /// 名
        /// </summary>
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        /// <summary>
        /// 姓ひらがな
        /// </summary>
        [Required]
        [StringLength(50)]
        public string LastNameHiragana { get; set; }

        /// <summary>
        /// 名ひらがな
        /// </summary>
        [Required]
        [StringLength(50)]
        public string FirstNameHiragana { get; set; }

        /// <summary>
        /// 年代ID
        /// </summary>
        [Required]
        public int AgeId { get; set; }

        /// <summary>
        /// 性別
        /// </summary>
        [Required]
        public int Sex { get; set; }

        /// <summary>
        /// 郵便番号
        /// </summary>
        [Required]
        [StringLength(8)]
        public string Zipcode { get; set; }

        /// <summary>
        /// 都道府県ID
        /// </summary>
        [Required]
        public int PrefectureId { get; set; }

        /// <summary>
        /// 市区町村
        /// </summary>
        [Required]
        [StringLength(200)]
        public string City { get; set; }

        /// <summary>
        /// 町名・番地
        /// </summary>
        [Required]
        [StringLength(200)]
        public string StreetBunchName { get; set; }

        /// <summary>
        /// 建物・マンション名
        /// </summary>
        [Required]
        [StringLength(200)]
        public string BuildingName { get; set; }

        /// <summary>
        /// 電話番号
        /// </summary>
        [Required]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 職業ID
        /// </summary>
        [Required]
        public int JobId { get; set; }

        /// <summary>
        /// メールアドレス
        /// </summary>
        [Required]
        [StringLength(256)]
        public string MailAddress { get; set; }

        /// <summary>
        /// 登録日時
        /// </summary>
        [Required]
        [StringLength(20)]
        public string InsertDate { get; set; }

        /// <summary>
        /// 登録者
        /// </summary>
        [Required]
        [StringLength(100)]
        public string InsertUser { get; set; }

        /// <summary>
        /// 更新日時
        /// </summary>
        [Required]
        [StringLength(20)]
        public string UpdateDate { get; set; }

        /// <summary>
        /// 更新者
        /// </summary>
        [Required]
        [StringLength(100)]
        public string UpdateUser { get; set; }
    }
}
