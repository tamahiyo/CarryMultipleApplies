namespace CarryMultipleAppliesDataAccess.DataTier.Core.Domain
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class M_Jobs
    {
        /// <summary>
        /// E‹ÆID
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long JobId { get; set; }

        /// <summary>
        /// E‹Æ–¼
        /// </summary>
        [Required]
        [StringLength(50)]
        public string JobName { get; set; }

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
