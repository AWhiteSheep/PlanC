using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.EntityDataModel
{
    public partial class Roles
    {
        public Roles()
        {
            RolesUtilisateur = new HashSet<RolesUtilisateur>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(50)]
        public string Titre { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; }

        [InverseProperty("Role")]
        public virtual ICollection<RolesUtilisateur> RolesUtilisateur { get; set; }
    }
}
