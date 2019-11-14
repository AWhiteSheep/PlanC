using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.EntityDataModel
{
    public partial class MaterielsCours
    {
        [Key]
        [Column("CoursID")]
        [StringLength(10)]
        public string CoursId { get; set; }
        [Key]
        [Column("TCHR_UID")]
        [StringLength(7)]
        public string TchrUid { get; set; }
        [Key]
        [Column("PLN_VSN_CDTTM", TypeName = "datetime")]
        public DateTime PlnVsnCdttm { get; set; }
        [Key]
        [Column("SessionID")]
        [StringLength(3)]
        public string SessionId { get; set; }
        [Key]
        [Column("MaterielSQNBR")]
        public short MaterielSqnbr { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; }
        [Column("TRK_UID")]
        [StringLength(7)]
        public string TrkUid { get; set; }

        [ForeignKey("CoursId,TchrUid,PlnVsnCdttm,SessionId")]
        [InverseProperty("MaterielsCours")]
        public virtual PlansCours PlansCours { get; set; }
    }
}
