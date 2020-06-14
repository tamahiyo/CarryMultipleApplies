namespace CarryMultipleAppliesDataAccess.DataTier.Core.Domain
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class T_ApplyHistories
    {
        /// <summary>
        /// ���嗚��ID
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ApplyHistoryId { get; set; }

        /// <summary>
        /// ���O�I�����[�U�[��
        /// </summary>
        [Required]
        [StringLength(20)]
        public string UserName { get; set; }

        /// <summary>
        /// �X�ܕʃC�x���gID
        /// </summary>
        public int StoreEventId { get; set; }

        /// <summary>
        /// �V���A��No
        /// </summary>
        [Required]
        [StringLength(50)]
        public string SerialNo { get; set; }

        /// <summary>
        /// ��
        /// </summary>
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        /// <summary>
        /// ��
        /// </summary>
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        /// <summary>
        /// ���Ђ炪��
        /// </summary>
        [Required]
        [StringLength(50)]
        public string LastNameHiragana { get; set; }

        /// <summary>
        /// ���Ђ炪��
        /// </summary>
        [Required]
        [StringLength(50)]
        public string FirstNameHiragana { get; set; }

        /// <summary>
        /// �N��ID
        /// </summary>
        public int AgeId { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public int Sex { get; set; }

        /// <summary>
        /// �X�֔ԍ�
        /// </summary>
        [Required]
        [StringLength(8)]
        public string Zipcode { get; set; }

        /// <summary>
        /// �s���{��ID
        /// </summary>
        public int PrefectureId { get; set; }

        /// <summary>
        /// �s�撬��
        /// </summary>
        [Required]
        [StringLength(200)]
        public string City { get; set; }

        /// <summary>
        /// �����E�Ԓn
        /// </summary>
        [Required]
        [StringLength(200)]
        public string StreetBunchName { get; set; }

        /// <summary>
        /// �����E�}���V������
        /// </summary>
        [StringLength(200)]
        public string BuildingName { get; set; }

        /// <summary>
        /// �d�b�ԍ�
        /// </summary>
        [Required]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// �E��ID
        /// </summary>
        public int JobId { get; set; }

        /// <summary>
        /// ���[���A�h���X
        /// </summary>
        [Required]
        [StringLength(256)]
        public string MailAddress { get; set; }

        /// <summary>
        /// �����
        /// </summary>
        public int AppliesStatusType { get; set; }

        /// <summary>
        /// ����󋵃��b�Z�[�W
        /// </summary>
        public string AppliesStatusMessage { get; set; }

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
