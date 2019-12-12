using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.EntityDataModel
{
    public partial class ExamensFinalsCertificatifs
    {
        [Key]
        [Column("CoursID")]
        [StringLength(10)]
        public string CoursId { get; set; }
        [Key]
        [Column("VSN_CDTTM", TypeName = "datetime")]
        public DateTime VsnCdttm { get; set; }
        [Key]
        [Column("ExamenID")]
        public int ExamenId { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; }
        [Column("TRK_UID")]
        [StringLength(7)]
        public string TrkUid { get; set; }

        [ForeignKey(nameof(ExamenId))]
        [InverseProperty(nameof(Examens.ExamensFinalsCertificatifs))]
        public virtual Examens Examen { get; set; }
        [ForeignKey("CoursId,VsnCdttm")]
        [InverseProperty("ExamensFinalsCertificatifs")]
        public virtual PlansCadres PlansCadres { get; set; }
    }
}
