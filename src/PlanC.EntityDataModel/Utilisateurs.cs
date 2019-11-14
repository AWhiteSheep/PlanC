using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.EntityDataModel
{
    public partial class Utilisateurs
    {
        public Utilisateurs()
        {
            DisponibilitesUtilisateur = new HashSet<DisponibilitesUtilisateur>();
            RolesUtilisateur = new HashSet<RolesUtilisateur>();
        }

        [Key]
        [Column("ID")]
        [StringLength(7)]
        public string Id { get; set; }
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
        [InverseProperty(nameof(Departements.Utilisateurs))]
        public virtual Departements Departement { get; set; }
        [InverseProperty("U")]
        public virtual ICollection<DisponibilitesUtilisateur> DisponibilitesUtilisateur { get; set; }
        [InverseProperty("Utilisateur")]
        public virtual ICollection<RolesUtilisateur> RolesUtilisateur { get; set; }
    }
}
