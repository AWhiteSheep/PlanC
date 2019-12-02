using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.EntityDataModel
{
    public partial class ExamensElementsCompetences
    {
        [Key]
        public int IdentityKey { get; set; }
        [Column("ExamenID")]
        public int ExamenId { get; set; }
        [StringLength(100)]
        public string ElementCompetenceId { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal? PoidElement { get; set; }

        [ForeignKey(nameof(ElementCompetenceId))]
        [InverseProperty(nameof(ElementsCompetence.ExamensElementsCompetences))]
        public virtual ElementsCompetence ElementCompetence { get; set; }
        [ForeignKey(nameof(ExamenId))]
        [InverseProperty(nameof(Examens.ExamensElementsCompetences))]
        public virtual Examens Examen { get; set; }
    }
}
