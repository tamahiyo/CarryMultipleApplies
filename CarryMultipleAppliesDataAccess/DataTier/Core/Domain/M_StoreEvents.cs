namespace CarryMultipleAppliesDataAccess.DataTier.Core.Domain
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class M_StoreEvents
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public M_StoreEvents()
        {
            M_StoreEventDisplays = new HashSet<M_StoreEventDisplays>();
        }

        /// <summary>
        /// 店舗別イベントID
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StoreEventId { get; set; }

        /// <summary>
        /// イベントID
        /// </summary>
        public int EventId { get; set; }

        /// <summary>
        /// 店舗別イベント名
        /// </summary>
        [Required]
        [StringLength(50)]
        public string StoreEventName { get; set; }

        /// <summary>
        /// 応募先URL
        /// </summary>
        [Required]
        [StringLength(200)]
        public string ApplyUrl { get; set; }

        /// <summary>
        /// イベント日
        /// </summary>
        [StringLength(20)]
        public string EventDate { get; set; }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<M_StoreEventDisplays> M_StoreEventDisplays { get; set; }
    }
}
