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
        public int Identity { get; set; }
        [Required]
        [Column("CoursID")]
        [StringLength(10)]
        public string CoursId { get; set; }
        [Required]
        [Column("TCHR_UID")]
        [StringLength(7)]
        public string TchrUid { get; set; }
        [Column("PLN_VSN_CDTTM", TypeName = "datetime")]
        public DateTime PlnVsnCdttm { get; set; }
        [Required]
        [Column("SessionID")]
        [StringLength(3)]
        public string SessionId { get; set; }
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
        [InverseProperty("IdendityCoursActivityNavigation")]
        public virtual ICollection<CoursCompetenceElements> CoursCompetenceElements { get; set; }
    }
}
