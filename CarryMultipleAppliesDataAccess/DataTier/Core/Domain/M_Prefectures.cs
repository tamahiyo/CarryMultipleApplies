namespace CarryMultipleAppliesDataAccess.DataTier.Core.Domain
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class M_Prefectures
    {
        /// <summary>
        /// “s“¹•{Œ§ID
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PrefectureId { get; set; }

        /// <summary>
        /// “s“¹•{Œ§–¼
        /// </summary>
        [Required]
        [StringLength(20)]
        public string PrefectureName { get; set; }

        /// <summary>
        /// “o˜^“ú
        /// </summary>
        [Required]
        [StringLength(20)]
        public string InsertDate { get; set; }

        /// <summary>
        /// “o˜^Ò
        /// </summary>
        [Required]
        [StringLength(100)]
        public string InsertUser { get; set; }

        /// <summary>
        /// XV“ú
        /// </summary>
        [Required]
        [StringLength(20)]
        public string UpdateDate { get; set; }

        /// <summary>
        /// XVÒ
        /// </summary>
        [Required]
        [StringLength(100)]
        public string UpdateUser { get; set; }
    }
}
