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
        // à ne pas se référer n'est pas la clé primaire mais bien un clef de récupration
        [IgnoreDataMember]
        public override string Id { get; set; } // FALLBACK KEY

    }
}
