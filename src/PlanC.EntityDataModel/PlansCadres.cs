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
        [JsonIgnore]
        [IgnoreDataMember]
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

        [NotMapped]
        [JsonIgnore]
        [IgnoreDataMember]
        public int TheoryHoursAccessor 
        {
            get 
            {
                return HeuresTotalesTheorie.GetValueOrDefault();
            }
            set
            {
                HeuresTotalesTheorie = value;
            } 
        }
        [NotMapped]
        [JsonIgnore]
        [IgnoreDataMember]
        public int PracticeHoursAccessor
        {
            get
            {
                return HeuresTotalesPratique.GetValueOrDefault();
            }
            set
            {
                HeuresTotalesPratique = value;
            }
        }
        [NotMapped]
        [JsonIgnore]
        [IgnoreDataMember]
        public int HomeHoursAccessor
        {
            get
            {
                return HeuresTotalesMaison.GetValueOrDefault();
            }
            set
            {
                HeuresTotalesMaison = value;
            }
        }

        [NotMapped]
        [JsonIgnore]
        [IgnoreDataMember]
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
        [JsonIgnore]
        [IgnoreDataMember]
        public DateTime CmteDateAccessor
        {
            get
            {
                return DateApprobationCommite.HasValue ? DateApprobationCommite.Value : DateTime.Now;
            }
            set
            {
                DateApprobationCommite = value;
            }
        }
        [NotMapped]
        [JsonIgnore]
        [IgnoreDataMember]
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
    }
}
