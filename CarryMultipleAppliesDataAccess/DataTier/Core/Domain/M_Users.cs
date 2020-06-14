namespace CarryMultipleAppliesDataAccess.DataTier.Core.Domain
{
    using System.ComponentModel.DataAnnotations;

    public partial class M_Users
    {
        /// <summary>
        /// ���O�I�����[�U�[��
        /// </summary>
        [Key]
        [Required]
        [StringLength(20)]
        public string UserName { get; set; }

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
