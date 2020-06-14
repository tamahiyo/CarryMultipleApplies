namespace CarryMultipleAppliesDataAccess.DataTier.Core.Domain
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class M_StoreEventDisplays
    {
        /// <summary>
        /// �X�ܕʃC�x���g��ʖ���ID
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StoreEventDisplayId { get; set; }

        /// <summary>
        /// �C�x���gID
        /// </summary>
        public int StoreEventId { get; set; }

        /// <summary>
        /// ��ʖ���
        /// </summary>
        [Required]
        [StringLength(20)]
        public string DisplayName { get; set; }

        /// <summary>
        /// ��ʖ���Prefix
        /// </summary>
        [Required]
        [StringLength(50)]
        public string DisplayNamePrefix { get; set; }

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

        public virtual M_StoreEvents M_StoreEvents { get; set; }
    }
}
