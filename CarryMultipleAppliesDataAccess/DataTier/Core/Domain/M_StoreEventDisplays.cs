namespace CarryMultipleAppliesDataAccess.DataTier.Core.Domain
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class M_StoreEventDisplays
    {
        /// <summary>
        /// 店舗別イベント画面名称ID
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StoreEventDisplayId { get; set; }

        /// <summary>
        /// イベントID
        /// </summary>
        public int StoreEventId { get; set; }

        /// <summary>
        /// 画面名称
        /// </summary>
        [Required]
        [StringLength(20)]
        public string DisplayName { get; set; }

        /// <summary>
        /// 画面名称Prefix
        /// </summary>
        [Required]
        [StringLength(50)]
        public string DisplayNamePrefix { get; set; }

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

        public virtual M_StoreEvents M_StoreEvents { get; set; }
    }
}
