using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PlanC.EntityDataModel
{
    public partial class CoursCompetenceElements
    {
        [Key]
        public int IdentityCritereElementCompetence { get; set; }
        [Key]
        public int IdendityCoursActivity { get; set; }
        [Key]
        [Column("AcitiviteSQNBR")]
        public int AcitiviteSqnbr { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; }
        [Column("TRK_UID")]
        [StringLength(7)]
        public string TrkUid { get; set; }

        [ForeignKey(nameof(IdendityCoursActivity))]
        [InverseProperty(nameof(CoursActivite.CoursCompetenceElements))]
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual CoursActivite IdendityCoursActivityNavigation { get; set; }
        [ForeignKey(nameof(IdentityCritereElementCompetence))]
        [InverseProperty(nameof(CriteresElementCompetence.CoursCompetenceElements))]
        public virtual CriteresElementCompetence IdentityCritereElementCompetenceNavigation { get; set; }
    }
}
