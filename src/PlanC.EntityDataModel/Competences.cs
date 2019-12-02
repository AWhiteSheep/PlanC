using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        }

        [Key]
        public int IdentityKey { get; set; }
        [Required]
        [Column("CompetenceID")]
        [StringLength(4)]
        public string CompetenceId { get; set; }
        [Required]
        [Column("DisciplineID")]
        public int DisciplineId { get; set; }
        [Required]
        [StringLength(200)]
        public string Enonce { get; set; }
        [Required]
        [Column(TypeName = "ntext")]
        public string AttitudeAttendu { get; set; }
        public int NombreParties { get; set; }
        public bool CompetenceComplementaire { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; }
        [Column("TRK_UID")]
        [StringLength(7)]
        public string TrkUid { get; set; }

        [ForeignKey(nameof(DisciplineId))]
        [InverseProperty(nameof(Departements.Competences))]
        public virtual Departements Discipline { get; set; }
        [InverseProperty("IdentityKeyCompetenceNavigation")]
        public virtual ICollection<CompetenceContextes> CompetenceContextes { get; set; }
        [InverseProperty("IdentityKeyCompetencesNavigation")]
        public virtual ICollection<ElementsCompetence> ElementsCompetence { get; set; }

        public override string ToString()
        {
            return $"{CompetenceId} -- {Enonce}";
        }
    }
}
