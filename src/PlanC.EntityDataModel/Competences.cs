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
        [Column("CompetenceID")]
        [Required(ErrorMessage = "L'identifiant de la compétence est obligatoire.")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "La compétence doit être être une combinaison de 4 charactères alphanumériques.")]
        public string CompetenceId { get; set; }
        [Key]
        [Column("DisciplineID")]
        [Range(0, int.MaxValue, ErrorMessage = "Le champ est incorrect.")]
        [Required(ErrorMessage = "La discipline doit être sélectionné.")]
        public int DisciplineId { get; set; }
        [Required(ErrorMessage = "L'énoncé de la compétence est un champ obligatoire.")]
        [StringLength(200, ErrorMessage = "Le champ est incorrect.")]
        public string Enonce { get; set; }
        [Column(TypeName = "ntext")]
        [Required(ErrorMessage = "L'attitude attendu est un champ obligatoire.")]
        public string AttitudeAttendu { get; set; }
        [Column(TypeName = "TINYINT")]
        [Required(ErrorMessage = "Le nombre de parties est un champ obligatoire.")]
        [Range(1, int.MaxValue, ErrorMessage = "Nombre de parti minimum: 1.")]
        public int NombreParties { get; set; } = 1;
        public bool CompetenceComplementaire { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; }
        [Column("TRK_UID")]
        [StringLength(7)]
        public string TrkUid { get; set; }

        [ForeignKey(nameof(DisciplineId))]
        [InverseProperty(nameof(Departements.Competences))]
        public virtual Departements Discipline { get; set; }
        [InverseProperty("Competences")]
        public virtual ICollection<CompetenceContextes> CompetenceContextes { get; set; }
        [InverseProperty("Competences")]
        public virtual ICollection<ElementsCompetence> ElementsCompetence { get; set; }
    }
}
