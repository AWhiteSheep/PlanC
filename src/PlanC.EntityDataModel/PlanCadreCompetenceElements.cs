using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.EntityDataModel
{
    public partial class PlanCadreCompetenceElements
    {
        [Key]
        public int IdentityKey { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [Column("CoursID")]
        [StringLength(10)]
        public string CoursId { get; set; }
        [StringLength(100)]
        public string ElementCompetenceId { get; set; }
        [Column("PRTL_SKL_IND")]
        [StringLength(1)]
        public string PrtlSklInd { get; set; }
        [Column("TXNMY_CD")]
        [StringLength(2)]
        public string TxnmyCd { get; set; }
        [Column(TypeName = "ntext")]
        public string LongDescription { get; set; }
        [Column("VSN_CDTTM", TypeName = "datetime")]
        public DateTime VsnCdttm { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; }
        [Column("TRK_UID")]
        [StringLength(7)]
        public string TrkUid { get; set; }

        [ForeignKey(nameof(ElementCompetenceId))]
        [InverseProperty(nameof(ElementsCompetence.PlanCadreCompetenceElements))]
        public virtual ElementsCompetence ElementCompetence { get; set; }
        [ForeignKey("CoursId,VsnCdttm")]
        [InverseProperty("PlanCadreCompetenceElements")]
        public virtual PlansCadres PlansCadres { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        public bool IsPartial
        {
            get
            {
                return PrtlSklInd == "1";
            }
            set
            {
                PrtlSklInd = value ? "1" : "0";
            }
        }
    }
}
