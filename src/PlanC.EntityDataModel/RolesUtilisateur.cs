using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.EntityDataModel
{
    public partial class RolesUtilisateur
    {
        [Key]
        [Column("UtilisateurID")]
        [StringLength(7)]
        public string UtilisateurId { get; set; }
        [Key]
        [Column("RoleID")]
        public int RoleId { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; }

        [ForeignKey(nameof(RoleId))]
        [InverseProperty(nameof(Roles.RolesUtilisateur))]
        public virtual Roles Role { get; set; }
        [ForeignKey(nameof(UtilisateurId))]
        [InverseProperty(nameof(Utilisateurs.RolesUtilisateur))]
        public virtual Utilisateurs Utilisateur { get; set; }
    }
}
