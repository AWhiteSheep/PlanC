using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.EntityDataModel
{
    [Table("RelTablPCrsPCadres")]
    public partial class RelTablPcrsPcadres
    {
        [Key]
        [Column("PlCoursCrsID")]
        [StringLength(10)]
        public string PlCoursCrsId { get; set; }
        [Key]
        [Column("PlCrsTCHR_UID")]
        [StringLength(7)]
        public string PlCrsTchrUid { get; set; }
        [Key]
        [Column("PlCrsPLN_VSN_CDTTM", TypeName = "datetime")]
        public DateTime PlCrsPlnVsnCdttm { get; set; }
        [Key]
        [Column("PlCrsSessionID")]
        [StringLength(3)]
        public string PlCrsSessionId { get; set; }
        [Key]
        [StringLength(10)]
        public string PlCadreId { get; set; }
        [Key]
        [Column(TypeName = "datetime")]
        public DateTime PlVsnCdttm { get; set; }

        [ForeignKey("PlCadreId,PlVsnCdttm")]
        [InverseProperty(nameof(PlansCadres.RelTablPcrsPcadres))]
        public virtual PlansCadres Pl { get; set; }
        [ForeignKey("PlCoursCrsId,PlCrsTchrUid,PlCrsPlnVsnCdttm,PlCrsSessionId")]
        [InverseProperty(nameof(PlansCours.RelTablPcrsPcadres))]
        public virtual PlansCours PlC { get; set; }
    }
}
