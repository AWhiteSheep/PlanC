using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.EntityDataModel
{
    public partial class ExamensElementsCompetences
    {
        [Key]
        [Column("ExamenID")]
        public int ExamenId { get; set; }
        [Column("DisciplineID")]
        public int DisciplineId { get; set; }
        [Key]
        [Column("CompetenceID")]
        [StringLength(4)]
        public string CompetenceId { get; set; }
        [Key]
        [Column("ElementCompetenceSQNBR")]
        public byte ElementCompetenceSqnbr { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal? PoidElement { get; set; }

        [ForeignKey("CompetenceId,DisciplineId,ElementCompetenceSqnbr")]
        [InverseProperty("ExamensElementsCompetences")]
        public virtual ElementsCompetence ElementsCompetence { get; set; }
        [ForeignKey(nameof(ExamenId))]
        [InverseProperty(nameof(Examens.ExamensElementsCompetences))]
        public virtual Examens Examen { get; set; }
    }
}
