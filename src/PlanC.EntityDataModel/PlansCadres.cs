using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

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
                return Unites.GetValueOrDefault(0);
            }
            set
            {
                Unites = decimal.Round(value, 2);
            }
        }

        [NotMapped]
        public int TheoryHoursAccessor 
        {
            get 
            {
                return HeuresTotalesTheorie.GetValueOrDefault(0);
            }
            set
            {
                HeuresTotalesTheorie = value;
            } 
        }
        [NotMapped]
        public int PracticeHoursAccessor
        {
            get
            {
                return HeuresTotalesPratique.GetValueOrDefault(0);
            }
            set
            {
                HeuresTotalesPratique = value;
            }
        }
        [NotMapped]
        public int HomeHoursAccessor
        {
            get
            {
                return HeuresTotalesMaison.GetValueOrDefault(0);
            }
            set
            {
                HeuresTotalesMaison = value;
            }
        }

        [NotMapped]
        public DateTime DptDateAccessor
        {
            get
            {
                return DateApprobationDepartement.GetValueOrDefault();
            }
            set
            {
                DateApprobationDepartement = value;
            }
        }
        [NotMapped]
        public DateTime CmteDateAccessor
        {
            get
            {
                return DateApprobationCommite.GetValueOrDefault();
            }
            set
            {
                DateApprobationCommite = value;
            }
        }
        [NotMapped]
        public DateTime DirectorDateAccessor
        {
            get
            {
                return DateApprobationCadre.GetValueOrDefault();
            }
            set
            {
                DateApprobationCadre = value;
            }
        }
        [NotMapped]
        public DateTime RcdCdttmAccess
        {
            get
            {
                return RcdCdttm.GetValueOrDefault();
            }
            set
            {
                RcdCdttm = value;
            }
        }

        [NotMapped]
        public string DptDateString
        {
            get
            {
                return DateApprobationDepartement?.ToString() ?? "<i class='fas fa-mug-hot'></i>";
            }
        }
        [NotMapped]
        public string CmteDateString
        {
            get
            {
                return DateApprobationCommite?.ToString() ?? "<i class='fas fa-mug-hot'></i>";
            }
        }
        [NotMapped]
        public string DirectorDateString
        {
            get
            {
                return DateApprobationCadre?.ToString() ?? "<i class='fas fa-mug-hot'></i>";
            }
        }
        [NotMapped]
        public string RcdCdttmString
        {
            get
            {
                return RcdCdttm?.ToString() ?? "<i class='fas fa-mug-hot'></i>";
            }
        }
    }
}
