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
    public partial class Utilisateurs : IdentityUser
    {
        public Utilisateurs() : base()
        {
            DisponibilitesUtilisateur = new HashSet<DisponibilitesUtilisateur>();
        }

        public Utilisateurs(string userName) : base(userName)
        {
        }

        [Key]
        [Column("ID")]
        [StringLength(7)]
        public override string Id { get; set; }
        [Column("DepartementID")]
        [PersonalData]
        public int? DepartementId { get; set; }
        [Column("GVN_NM")]
        [StringLength(50)]
        [PersonalData]
        public string GvnNm { get; set; } // prénom
        [Column("SNM")]
        [StringLength(50)]
        public string Snm { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        [PersonalData]
        public DateTime? RcdCdttm { get; set; }

        [ForeignKey(nameof(DepartementId))]
        [InverseProperty(nameof(Departements.Utilisateurs))]
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Departements Departement { get; set; }
        [InverseProperty("U")]
        public virtual ICollection<DisponibilitesUtilisateur> DisponibilitesUtilisateur { get; set; }
    }
}
