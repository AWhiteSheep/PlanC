using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.EntityDataModel
{
    public partial class CoursRequis
    {
        [Key]
        [Column("CoursID")]
        [StringLength(10)]
        public string CoursId { get; set; }
        [Key]
        [Column("VSN_CDTTM", TypeName = "datetime")]
        public DateTime VsnCdttm { get; set; }
        [Key]
        [Column("CoursRequisID")]
        [StringLength(10)]
        public string CoursRequisId { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; }
        [Column("CRS_REQ_TY_CD")]
        [StringLength(2)]
        public string CrsReqTyCd { get; set; }
        [Column("TRK_UID")]
        [StringLength(7)]
        public string TrkUid { get; set; }

        [ForeignKey("CoursId,VsnCdttm")]
        [InverseProperty("CoursRequis")]
        public virtual PlansCadres PlansCadres { get; set; }
    }
}
