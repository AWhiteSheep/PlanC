using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.EntityDataModel
{
    public partial class ElementsCompetence
    {
        public ElementsCompetence()
        {
            CriteresElementCompetence = new HashSet<CriteresElementCompetence>();
            ExamensElementsCompetences = new HashSet<ExamensElementsCompetences>();
        }

        [Key]
        [Column("CompetenceID")]
        [StringLength(4)]
        public string CompetenceId { get; set; }
        [Key]
        [Column("DisciplineID")]
        public int DisciplineId { get; set; }
        [Key]
        [Column("ElementCompetenceSQNBR")]
        public byte ElementCompetenceSqnbr { get; set; }
        [StringLength(255)]
        public string Libele { get; set; }
        [Column(TypeName = "ntext")]
        public string Description { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; }
        [Column("TRK_UID")]
        [StringLength(7)]
        public string TrkUid { get; set; }

        [ForeignKey("CompetenceId,DisciplineId")]
        [InverseProperty("ElementsCompetence")]
        public virtual Competences Competences { get; set; }
        [InverseProperty("ElementsCompetence")]
        public virtual ICollection<CriteresElementCompetence> CriteresElementCompetence { get; set; }
        [InverseProperty("ElementsCompetence")]
        public virtual ICollection<ExamensElementsCompetences> ExamensElementsCompetences { get; set; }
    }
}
