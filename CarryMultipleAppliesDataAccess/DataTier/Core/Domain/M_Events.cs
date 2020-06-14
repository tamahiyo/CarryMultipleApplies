namespace CarryMultipleAppliesDataAccess.DataTier.Core.Domain
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class M_Events
    {
        /// <summary>
        /// �C�x���gID
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EventId { get; set; }

        /// <summary>
        /// �C�x���g��
        /// </summary>
        [Required]
        [StringLength(200)]
        public string EventName { get; set; }

        /// <summary>
        /// ������ԊJ�n
        /// </summary>
        [Required]
        [StringLength(20)]
        public string ApplyFrom { get; set; }

        /// <summary>
        /// ������ԏI��
        /// </summary>
        [Required]
        [StringLength(20)]
        public string ApplyTo { get; set; }

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
    }
}
