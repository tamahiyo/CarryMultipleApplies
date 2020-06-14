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
        /// �X�ܕʃC�x���gID
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StoreEventId { get; set; }

        /// <summary>
        /// �C�x���gID
        /// </summary>
        public int EventId { get; set; }

        /// <summary>
        /// �X�ܕʃC�x���g��
        /// </summary>
        [Required]
        [StringLength(50)]
        public string StoreEventName { get; set; }

        /// <summary>
        /// �����URL
        /// </summary>
        [Required]
        [StringLength(200)]
        public string ApplyUrl { get; set; }

        /// <summary>
        /// �C�x���g��
        /// </summary>
        [StringLength(20)]
        public string EventDate { get; set; }

        /// <summary>
        /// �o�^����
        /// </summary>
        [Required]
        [StringLength(20)]
        public string InsertDate { get; set; }

        /// <summary>
        /// �o�^��
        /// </summary>
        [Required]
        [StringLength(100)]
        public string InsertUser { get; set; }

        /// <summary>
        /// �X�V����
        /// </summary>
        [Required]
        [StringLength(20)]
        public string UpdateDate { get; set; }

        /// <summary>
        /// �X�V��
        /// </summary>
        [Required]
        [StringLength(100)]
        public string UpdateUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<M_StoreEventDisplays> M_StoreEventDisplays { get; set; }
    }
}
