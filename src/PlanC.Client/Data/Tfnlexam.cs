using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.Client.Data
{
    [Table("TFNLEXAM")]
    public partial class Tfnlexam
    {
        [Key]
        [Column("CRS_ID")]
        [StringLength(10)]
        public string CrsId { get; set; }
        [Key]
        [Column("VSN_CDTTM", TypeName = "datetime")]
        public DateTime VsnCdttm { get; set; }
        [Key]
        [Column("EXAM_ID")]
        public int ExamId { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; }
        [Column("TRK_UID")]
        [StringLength(7)]
        public string TrkUid { get; set; }

        [ForeignKey(nameof(ExamId))]
        [InverseProperty(nameof(Texam.Tfnlexam))]
        public virtual Texam Exam { get; set; }
        [ForeignKey("CrsId,VsnCdttm")]
        [InverseProperty("Tfnlexam")]
        public virtual Tcrstmplt Tcrstmplt { get; set; }
    }
}
