using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.Client.Data
{
    [Table("TEXAM")]
    public partial class Texam
    {
        public Texam()
        {
            Tcertexam = new HashSet<Tcertexam>();
            Texamsklelem = new HashSet<Texamsklelem>();
            Tfnlexam = new HashSet<Tfnlexam>();
        }

        [Key]
        [Column("EXAM_ID")]
        public int ExamId { get; set; }
        [Column("EXAM_TY_CD")]
        [StringLength(2)]
        public string ExamTyCd { get; set; }
        [Column("EXAM_TITLE")]
        [StringLength(150)]
        public string ExamTitle { get; set; }
        [Column("EXAM_WGHT", TypeName = "decimal(5, 2)")]
        public decimal? ExamWght { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; }
        [Column("TRK_UID")]
        [StringLength(7)]
        public string TrkUid { get; set; }

        [InverseProperty("Exam")]
        public virtual ICollection<Tcertexam> Tcertexam { get; set; }
        [InverseProperty("Exam")]
        public virtual ICollection<Texamsklelem> Texamsklelem { get; set; }
        [InverseProperty("Exam")]
        public virtual ICollection<Tfnlexam> Tfnlexam { get; set; }
    }
}
