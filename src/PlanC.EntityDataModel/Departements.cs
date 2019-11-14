using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.EntityDataModel
{
    public partial class Departements
    {
        public Departements()
        {
            Competences = new HashSet<Competences>();
            Programmes = new HashSet<Programmes>();
            Utilisateurs = new HashSet<Utilisateurs>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(250)]
        public string Titre { get; set; }
        [Column(TypeName = "ntext")]
        public string Politique { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; }
        [Column("TRK_UID")]
        [StringLength(7)]
        public string TrkUid { get; set; }

        [InverseProperty("Discipline")]
        public virtual ICollection<Competences> Competences { get; set; }
        [InverseProperty("Departement")]
        public virtual ICollection<Programmes> Programmes { get; set; }
        [InverseProperty("Departement")]
        public virtual ICollection<Utilisateurs> Utilisateurs { get; set; }
    }
}
