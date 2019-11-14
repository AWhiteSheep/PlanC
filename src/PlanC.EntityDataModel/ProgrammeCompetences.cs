using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.EntityDataModel
{
    public partial class ProgrammeCompetences
    {
        [Key]
        [Column("ProgrammeID")]
        [StringLength(6)]
        public string ProgrammeId { get; set; }
        [Key]
        [Column("DepartementID")]
        public int DepartementId { get; set; }
        [Key]
        [Column("CompetenceID")]
        [StringLength(4)]
        public string CompetenceId { get; set; }
        public bool CompetenceEstRequise { get; set; }
        public bool CompetenceEstComplentaire { get; set; }

        [ForeignKey(nameof(CompetenceId))]
        [InverseProperty(nameof(Competences.ProgrammeCompetences))]
        public virtual Competences Competence { get; set; }
        [ForeignKey("ProgrammeId,DepartementId")]
        [InverseProperty("ProgrammeCompetences")]
        public virtual Programmes Programmes { get; set; }
    }
}
