using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.EntityDataModel
{
    public partial class Programmes
    {
        public Programmes()
        {
            ProgrammeCompetences = new HashSet<ProgrammeCompetences>();
        }

        [Key]
        [Column("ID")]
        [StringLength(6)]
        public string Id { get; set; }
        [Key]
        [Column("DepartementID")]
        public int DepartementId { get; set; }
        [StringLength(50)]
        public string Designation { get; set; }
        [Column(TypeName = "ntext")]
        public string Description { get; set; }
        [Column("ProgrammePDF", TypeName = "ntext")]
        public string ProgrammePdf { get; set; }
        [Column("ProgrammeIMG")]
        public string ProgrammeImg { get; set; }
        [StringLength(2)]
        public string CodeType { get; set; }
        public int? NombreCompetencesObligatoires { get; set; }
        public int? NombreCompetencesOptionnelles { get; set; }
        public int? NombreCompetencesComplementaires { get; set; }
        [StringLength(3)]
        public string TypeDegreFormation { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; }
        [Column("TRK_UID")]
        [StringLength(7)]
        public string TrkUid { get; set; }

        [ForeignKey(nameof(CodeType))]
        [InverseProperty(nameof(CategoriesProgrammes.Programmes))]
        public virtual CategoriesProgrammes CodeTypeNavigation { get; set; }
        [ForeignKey(nameof(DepartementId))]
        [InverseProperty(nameof(Departements.Programmes))]
        public virtual Departements Departement { get; set; }
        [ForeignKey(nameof(TypeDegreFormation))]
        [InverseProperty(nameof(TypesFormationsProgrammes.Programmes))]
        public virtual TypesFormationsProgrammes TypeDegreFormationNavigation { get; set; }
        [InverseProperty("Programmes")]
        public virtual ICollection<ProgrammeCompetences> ProgrammeCompetences { get; set; }
    }
}
