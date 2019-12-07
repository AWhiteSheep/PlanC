using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.EntityDataModel
{
    public partial class PlansCadres
    {
        public PlansCadres()
        {
            CoursRequis = new HashSet<CoursRequis>();
            ExamensFinalsCertificatifs = new HashSet<ExamensFinalsCertificatifs>();
            PlanCadreCompetenceElements = new HashSet<PlanCadreCompetenceElements>();
        }

        [Key]
        [Column("CoursID")]
        [Required]
        [StringLength(10)]
        public string CoursId { get; set; }
        [Key]
        [Column("VSN_CDTTM", TypeName = "datetime")]
        public DateTime VsnCdttm { get; set; }
        [Column("ProgrammeID")]
        [StringLength(6)]
        public string ProgrammeId { get; set; }
        [StringLength(50)]
        public string DenominationCours { get; set; }
        [Column(TypeName = "decimal(3, 2)")]
        [Range(0, 9.99, ErrorMessage = "Format: 9.99")]
        public decimal? Unites { get; set; }
        [Column(TypeName = "ntext")]
        public string Description { get; set; }
        [Column(TypeName = "ntext")]
        public string IntentionEducative { get; set; }
        [Column(TypeName = "ntext")]
        public string IntentionPedagogique { get; set; }
        public int? HeuresTotalesTheorie { get; set; }
        public int? HeuresTotalesPratique { get; set; }
        public int? HeuresTotalesMaison { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateApprobationDepartement { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateApprobationCommite { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateApprobationCadre { get; set; }
        [Column("TRK_UID")]
        [StringLength(7)]
        public string TrkUid { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; }

        [InverseProperty("PlansCadres")]
        public virtual ICollection<CoursRequis> CoursRequis { get; set; }
        [InverseProperty("PlansCadres")]
        public virtual ICollection<ExamensFinalsCertificatifs> ExamensFinalsCertificatifs { get; set; }
        [InverseProperty("PlansCadres")]
        public virtual ICollection<PlanCadreCompetenceElements> PlanCadreCompetenceElements { get; set; }

        [NotMapped]
        [Range(0, 9.99, ErrorMessage = "Format: 9.99")]
        public decimal UnitsAccessor
        {
            get
            {
                return Unites.GetValueOrDefault();
            }
            set
            {
                Unites = decimal.Round(value, 2);
            }
        }
    }
}
