using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.EntityDataModel
{
    public partial class CoursActivite
    {
        public CoursActivite()
        {
            CoursCompetenceElements = new HashSet<CoursCompetenceElements>();
        }

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
        [Column("ACTVT_SQNBR")]
        public short ActvtSqnbr { get; set; }
        [Column("ACTVT_LGNTH")]
        public short? ActvtLgnth { get; set; }
        [Column("ACTVT_DESC", TypeName = "ntext")]
        public string ActvtDesc { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; }
        [Column("TRK_UID")]
        [StringLength(7)]
        public string TrkUid { get; set; }

        [ForeignKey("CoursId,TchrUid,PlnVsnCdttm,SessionId")]
        [InverseProperty("CoursActivite")]
        public virtual PlansCours PlansCours { get; set; }
        [InverseProperty("CoursActivite")]
        public virtual ICollection<CoursCompetenceElements> CoursCompetenceElements { get; set; }
    }
}
