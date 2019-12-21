﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PlanC.EntityDataModel
{
    public partial class Programmes
    {

        [NotMapped]
        public int NombreCompetencesObligatoiresAccessor
        {
            get
            {
                return NombreCompetencesObligatoires ?? 0;
            }
            set
            {
                NombreCompetencesObligatoires = value;
            }
        }
        [NotMapped]
        public int NombreCompetencesOptionnellesAccessor
        {
            get
            {
                return NombreCompetencesOptionnelles ?? 0;
            }
            set
            {
                NombreCompetencesOptionnelles = value;
            }
        }
        [NotMapped]
        public int NombreCompetencesComplementairesAccessor
        {
            get
            {
                return NombreCompetencesComplementaires ?? 0;
            }
            set
            {
                NombreCompetencesComplementaires = value;
            }
        }
        [NotMapped]
        public string DepartementIdHasString
        {
            get
            {
                return DepartementId.ToString();
            }
            set
            {
                DepartementId = int.Parse(value);
            }
        }
        [NotMapped]
        public string ProgrammePdfAccess
        {
            get
            {
                return ProgrammePdf ?? "ajouter le lien vers le pdf";
            }
            set
            {
                ProgrammePdf = value;
            }
        }
        [NotMapped]
        public string ProgrammeImgAccess
        {
            get
            {
                return ProgrammeImg ?? "ajouter le lien vers l'image";
            }
            set
            {
                ProgrammeImg = value;
            }
        }
        [NotMapped]
        public DateTime RcdCdttmAccess
        {
            get
            {
                return RcdCdttm ?? DateTime.MaxValue;
            }
            set
            {
                RcdCdttm = value;
            }
        }

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
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Departements Departement { get; set; }
        [ForeignKey(nameof(TypeDegreFormation))]
        [InverseProperty(nameof(TypesFormationsProgrammes.Programmes))]
        public virtual TypesFormationsProgrammes TypeDegreFormationNavigation { get; set; }
        [InverseProperty("Programmes")]
        public virtual ICollection<ProgrammeCompetences> ProgrammeCompetences { get; set; }

        public override string ToString()
        {
            return $"{Id} {Designation}";
        }
    }
}
