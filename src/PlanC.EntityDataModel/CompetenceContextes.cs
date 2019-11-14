using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.EntityDataModel
{
    public partial class CompetenceContextes
    {
        [Key]
        [Required]
        [Column("CompetenceID")]
        [StringLength(4)]
        public string CompetenceId { get; set; }
        [Key]
        [Column("ContexteID")]
        public int ContexteId { get; set; }
        [Required]
        [Column("Text")]
        public string Text { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; }

        [ForeignKey(nameof(CompetenceId))]
        [InverseProperty(nameof(Competences.CompetenceContextes))]
        public virtual Competences Competence { get; set; }
    }
}
