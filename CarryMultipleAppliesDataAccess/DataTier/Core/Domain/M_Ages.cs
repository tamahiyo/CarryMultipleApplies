namespace CarryMultipleAppliesDataAccess.DataTier.Core.Domain
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class M_Ages
    {
        /// <summary>
        /// �N��ID
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AgeId { get; set; }

        /// <summary>
        /// �N�㖼
        /// </summary>
        [Required]
        [StringLength(20)]
        public string AgeName { get; set; }

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
