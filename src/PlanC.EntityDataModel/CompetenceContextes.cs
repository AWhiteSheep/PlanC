using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.EntityDataModel
{
    public partial class CompetenceContextes
    {
        [Key]
        public int IdentityKeyCompetence { get; set; }
        [Key]
        [Column("ContexteID")]
        public int ContexteId { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "Le descriptif doit être au moins 6 charactères.")]
        public string Text { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; }

        [ForeignKey(nameof(IdentityKeyCompetence))]
        [InverseProperty(nameof(Competences.CompetenceContextes))]
        public virtual Competences IdentityKeyCompetenceNavigation { get; set; }
    }
}
