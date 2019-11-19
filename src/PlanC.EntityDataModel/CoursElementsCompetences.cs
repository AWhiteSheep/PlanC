using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.EntityDataModel
{
    public partial class CoursElementsCompetences
    {
        [Key]
        [Column("CoursID")]
        [StringLength(10)]
        public string CoursId { get; set; }
        [Key]
        [Column("VSN_CDTTM", TypeName = "datetime")]
        public DateTime VsnCdttm { get; set; }
        [Key]
        [Column("CompetenceID")]
        [StringLength(4)]
        public string CompetenceId { get; set; }
        [Key]
        [Column("ElementCompetenceQNBR")]
        public byte ElementCompetenceQnbr { get; set; }
        [Column("PRTL_SKL_IND", TypeName ="char")]
        [StringLength(1)]
        public string PrtlSklInd { get; set; }
        [Column("TXNMY_CD")]
        [StringLength(2)]
        public string TxnmyCd { get; set; }
        [Column(TypeName = "ntext")]
        public string LongDescription { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; }
        [Column("TRK_UID")]
        [StringLength(7)]
        public string TrkUid { get; set; }

        [ForeignKey("CoursId,VsnCdttm")]
        [InverseProperty("CoursElementsCompetences")]
        public virtual PlansCadres PlansCadres { get; set; }
    }
}
