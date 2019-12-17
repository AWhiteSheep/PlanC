using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

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
        public int IdentityKey { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [Column("CompetenceID")]
        [StringLength(4)]
        public string CompetenceId { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [Column("DisciplineID")]
        public int DisciplineId { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [StringLength(200)]
        public string Enonce { get; set; }
        [Column(TypeName = "ntext")]
        public string AttitudeAttendu { get; set; }
        public int NombreParties { get; set; }
        public bool? CompetenceComplementaire { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; }
        [Column("TRK_UID")]
        [StringLength(7)]
        public string TrkUid { get; set; }



        [NotMapped]
        [JsonIgnore]
        public List<string> GetContextListString
        {
            get
            {
                List<string> contexts = new List<string>();
                foreach (var context in CompetenceContextes)
                {
                    contexts.Add(context.Text);
                }
                return contexts;
            }
        }

        [ForeignKey(nameof(DisciplineId))]
        [InverseProperty(nameof(Departements.Competences))]
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Departements Discipline { get; set; }
        [InverseProperty("IdentityKeyCompetenceNavigation")]
        public virtual ICollection<CompetenceContextes> CompetenceContextes { get; set; }
        [InverseProperty("IdentityKeyCompetencesNavigation")]
        [IgnoreDataMember]
        public virtual ICollection<ElementsCompetence> ElementsCompetence { get; set; }

        public override string ToString()
        {
            return $"{CompetenceId} -- {Enonce}";
        }
    }
}
