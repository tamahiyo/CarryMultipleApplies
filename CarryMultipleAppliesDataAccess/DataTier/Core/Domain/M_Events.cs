namespace CarryMultipleAppliesDataAccess.DataTier.Core.Domain
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class M_Events
    {
        /// <summary>
        /// イベントID
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EventId { get; set; }

        /// <summary>
        /// イベント名
        /// </summary>
        [Required]
        [StringLength(200)]
        public string EventName { get; set; }

        /// <summary>
        /// 応募期間開始
        /// </summary>
        [Required]
        [StringLength(20)]
        public string ApplyFrom { get; set; }

        /// <summary>
        /// 応募期間終了
        /// </summary>
        [Required]
        [StringLength(20)]
        public string ApplyTo { get; set; }

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
