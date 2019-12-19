using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PlanC.EntityDataModel
{
    public partial class AspNetUsers : IdentityUser
    {
        public AspNetUsers() : base()
        {
            DisponibilitesUtilisateur = new HashSet<DisponibilitesUtilisateur>();
        }

        public AspNetUsers(string userName) : base(userName)
        {
        }

        [Key]
        [StringLength(7)]
        public override string UserName { get; set; }
        [Column("DepartementID")]
        public int? DepartementId { get; set; }
        [Column("GVN_NM")]
        [StringLength(50)]
        public string GvnNm { get; set; }
        public int? ImageProfilChoice { get ; set ; }
        [NotMapped]
        public int _ImageProfilChoice { get => ImageProfilChoice ?? 0; set => ImageProfilChoice = value; }
        public string Office { get; set; }
        [NotMapped]
        // renvoit le numéro d'office du professeur
        public string _Office {
            get
            {
                return string.IsNullOrEmpty(Office) ? "Non spécifié" : Office;
            }
         }
        public string Campus { get; set; }
        [NotMapped]
        // renvoit le nom du campus si n'est pas donné nous pouvons ne pas
        // renvoyé un NULL ne pouvant pas être lue de l'autre côté
        public string _Campus {
            get {
                return string.IsNullOrEmpty(Campus) ? "Gabrielle-Roy et Félix-Leclerc" : Campus;
            }
        }
        [Column("SNM")]
        [StringLength(50)]
        public string Snm { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; }

        [ForeignKey(nameof(DepartementId))]
        [InverseProperty(nameof(Departements.AspNetUsers))]
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Departements Departement { get; set; }
        [InverseProperty("U")]
        public virtual ICollection<DisponibilitesUtilisateur> DisponibilitesUtilisateur { get; set; }
        [NotMapped]
        public virtual string[] _DisponibilitesUtilisateur {
            get {
                if(DisponibilitesUtilisateur == null)
                    return new[] { "Non spécifié" };
                // la liste de dispo qui sera renvoyé en array
                List<string> dispos = new List<string>();
                foreach(var dispo in DisponibilitesUtilisateur)
                {
                    dispos.Add(dispo.DayOfWeekHumanLangageFR + " " + dispo.StartTimeSpan.ToString() + "-" + dispo.StopTimeSpan.ToString());
                }
                return dispos.ToArray();
            }
         }
        // à ne pas se référer n'est pas la clé primaire mais bien un clef de récupration
        [IgnoreDataMember]
        public override string Id { get; set; } // FALLBACK KEY
    }
}
