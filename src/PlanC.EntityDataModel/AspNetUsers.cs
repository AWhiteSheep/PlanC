using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PlanC.EntityDataModel
{
<<<<<<< HEAD:src/PlanC.EntityDataModel/AspNetUsers.cs
    public partial class AspNetUsers : IdentityUser
    {
        public AspNetUsers() : base()
=======
    public partial class Utilisateurs
    {
        public Utilisateurs()
>>>>>>> e6351150fbe926ea9dd68824e6c58e0603ec91b9:src/PlanC.EntityDataModel/Utilisateurs.cs
        {
            DisponibilitesUtilisateur = new HashSet<DisponibilitesUtilisateur>();
            RolesUtilisateur = new HashSet<RolesUtilisateur>();
        }

<<<<<<< HEAD:src/PlanC.EntityDataModel/AspNetUsers.cs
        public AspNetUsers(string userName) : base(userName)
        {
        }

        [Key]
        [StringLength(7)]
        public override string UserName { get; set; }
=======
        [Key]
        [Column("ID")]
        [StringLength(7)]
        public string Id { get; set; }
>>>>>>> e6351150fbe926ea9dd68824e6c58e0603ec91b9:src/PlanC.EntityDataModel/Utilisateurs.cs
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
<<<<<<< HEAD:src/PlanC.EntityDataModel/AspNetUsers.cs

        // à ne pas se référer n'est pas la clé primaire mais bien un clef de récupration
        [IgnoreDataMember]
        public override string Id { get; set; } // FALLBACK KEY
=======
        [InverseProperty("Utilisateur")]
        public virtual ICollection<RolesUtilisateur> RolesUtilisateur { get; set; }
>>>>>>> e6351150fbe926ea9dd68824e6c58e0603ec91b9:src/PlanC.EntityDataModel/Utilisateurs.cs
    }
}
