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
            PlanCadreCompetenceElements = new HashSet<PlanCadreCompetenceElements>();
        }

        [Key]
        [Column("ID")]
        [StringLength(100)]
        public string Id { get; set; }// auto généré
        public int IdentityKeyCompetences { get; set; }// association vers compétences
        [Column("ElementCompetenceSQNBR")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ElementCompetenceSqnbr { get; set; }// auto généré
        [StringLength(255)]
        public string Libele { get; set; }// à remplir
        [Column(TypeName = "ntext")]
        public string Description { get; set; }// à remplir
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime RcdCdttm { get; set; }
        [Column("TRK_UID")]
        [StringLength(7)]
        public string TrkUid { get; set; }

        [ForeignKey(nameof(IdentityKeyCompetences))]
        [InverseProperty(nameof(Competences.ElementsCompetence))]
        public virtual Competences IdentityKeyCompetencesNavigation { get; set; }
        [InverseProperty("ElementCompetence")]
        public virtual ICollection<CriteresElementCompetence> CriteresElementCompetence { get; set; }
        [InverseProperty("ElementCompetence")]
        public virtual ICollection<ExamensElementsCompetences> ExamensElementsCompetences { get; set; }
        [InverseProperty("ElementCompetence")]
        public virtual ICollection<PlanCadreCompetenceElements> PlanCadreCompetenceElements { get; set; }
    }
}
