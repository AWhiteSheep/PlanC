using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.Client.Data
{
    [Table("TCERTEXAM")]
    public partial class Tcertexam
    {
        [Key]
        [Column("CRS_ID")]
        [StringLength(10)]
        public string CrsId { get; set; }
        [Key]
        [Column("TCHR_UID")]
        [StringLength(7)]
        public string TchrUid { get; set; }
        [Key]
        [Column("PLN_VSN_CDTTM", TypeName = "datetime")]
        public DateTime PlnVsnCdttm { get; set; }
        [Key]
        [Column("SMSTR_ID")]
        [StringLength(3)]
        public string SmstrId { get; set; }
        [Key]
        [Column("EXAM_ID")]
        public int ExamId { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; }
        [Column("TRK_UID")]
        [StringLength(7)]
        public string TrkUid { get; set; }

        [ForeignKey(nameof(ExamId))]
        [InverseProperty(nameof(Texam.Tcertexam))]
        public virtual Texam Exam { get; set; }
        [ForeignKey("CrsId,TchrUid,PlnVsnCdttm,SmstrId")]
        [InverseProperty("Tcertexam")]
        public virtual Tcrspln Tcrspln { get; set; }
    }
}
