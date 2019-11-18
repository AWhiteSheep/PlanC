using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.EntityDataModel
{
    public partial class CompetenceContextes
    {
        [Key]
        [Column("CompetenceID")]
        [StringLength(4)]
        public string CompetenceId { get; set; }
        [Key]
        [Column("DepartementID")]
        public int DepartementId { get; set; }
        [Key]
        [Column("ContexteID")]
        public int ContexteId { get; set; }
        [Required]
        public string Text { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; }

        [ForeignKey("CompetenceId,DepartementId")]
        [InverseProperty("CompetenceContextes")]
        public virtual Competences Competences { get; set; }
    }
}
