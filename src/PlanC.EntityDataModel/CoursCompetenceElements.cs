using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.EntityDataModel
{
    public partial class CoursCompetenceElements
    {
        [Key]
        [Column("CompetenceID")]
        [StringLength(4)]
        public string CompetenceId { get; set; }
        [Key]
        [DataType("TINYINT")]
        [Column("ElementCompetenceSQNBR")]
        public byte ElementCompetenceSqnbr { get; set; }
        [Column("CritereElementCompetenceSQNBR")]
        [DataType("TINYINT")]
        public int? CritereElementCompetenceSqnbr { get; set; }
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
        [Column("AcitiviteSQNBR")]
        public short AcitiviteSqnbr { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; }
        [Column("TRK_UID")]
        [StringLength(7)]
        public string TrkUid { get; set; }

        [ForeignKey("CoursId,TchrUid,PlnVsnCdttm,SessionId,AcitiviteSqnbr")]
        [InverseProperty("CoursCompetenceElements")]
        public virtual CoursActivite CoursActivite { get; set; }
        [ForeignKey("CompetenceId,ElementCompetenceSqnbr,CritereElementCompetenceSqnbr")]
        [InverseProperty("CoursCompetenceElements")]
        public virtual CriteresElementCompetence CriteresElementCompetence { get; set; }
    }
}
