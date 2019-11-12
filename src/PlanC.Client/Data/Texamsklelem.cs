using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.Client.Data
{
    [Table("TEXAMSKLELEM")]
    public partial class Texamsklelem
    {
        [Key]
        [Column("EXAM_ID")]
        public int ExamId { get; set; }
        [Key]
        [Column("SKL_ID")]
        [StringLength(4)]
        public string SklId { get; set; }
        [Key]
        [Column("SKLELEM_SQNBR")]
        public short SklelemSqnbr { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; }
        [Column("SKLELEM_WGHT", TypeName = "decimal(5, 2)")]
        public decimal? SklelemWght { get; set; }

        [ForeignKey(nameof(ExamId))]
        [InverseProperty(nameof(Texam.Texamsklelem))]
        public virtual Texam Exam { get; set; }
        [ForeignKey("SklId,SklelemSqnbr")]
        [InverseProperty(nameof(Tsklelem.Texamsklelem))]
        public virtual Tsklelem Skl { get; set; }
    }
}
