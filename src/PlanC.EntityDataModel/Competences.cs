using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.EntityDataModel
{
    public partial class Competences
    {
        public Competences()
        {
            CompetenceContextes = new HashSet<CompetenceContextes>();
            ElementsCompetence = new HashSet<ElementsCompetence>();
            ProgrammeCompetences = new HashSet<ProgrammeCompetences>();
        }

        [Key]
        [Column("CompetenceID")]
        [StringLength(4)]
        public string CompetenceId { get; set; }
        [StringLength(200)]
        public string Enonce { get; set; }
        [Column(TypeName = "ntext")]
        public string AttitudeAttendu { get; set; }
        [Column("DisciplineID")]
        public int DisciplineId { get; set; }
        public byte NombreParties { get; set; }
        public bool? CompetenceComplementaire { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; }
        [Column("TRK_UID")]
        [StringLength(7)]
        public string TrkUid { get; set; }

        [ForeignKey(nameof(DisciplineId))]
        [InverseProperty(nameof(Departements.Competences))]
        public virtual Departements Discipline { get; set; }
        [InverseProperty("Competence")]
        public virtual ICollection<CompetenceContextes> CompetenceContextes { get; set; }
        [InverseProperty("Competence")]
        public virtual ICollection<ElementsCompetence> ElementsCompetence { get; set; }
        [InverseProperty("Competence")]
        public virtual ICollection<ProgrammeCompetences> ProgrammeCompetences { get; set; }
    }
}
