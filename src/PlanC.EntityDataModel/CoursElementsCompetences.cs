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
        [Column("CompetenceID")]
        [StringLength(4)]
        public string CompetenceId { get; set; }
        [Key]
        [Column("DisciplineId")]     
        public int DisciplineId { get; set; }
        [Key]
        [Column("ElementCompetenceQNBR", TypeName = "smallint")]
        public Int16 ElementCompetenceQnbr { get; set; }
        [Column("PRTL_SKL_IND")]
        [StringLength(1)]
        public string PrtlSklInd { get; set; }
        [Column("TXNMY_CD")]
        [StringLength(2)]
        public string TxnmyCd { get; set; }
        [Column(TypeName = "ntext")]
        public string LongDescription { get; set; }
        [Key]
        [Column("VSN_CDTTM", TypeName = "datetime")]
        public DateTime VsnCdttm { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; }
        [Column("TRK_UID")]
        [StringLength(7)]
        public string TrkUid { get; set; }

        [ForeignKey("CoursId,VsnCdttm")]
        [InverseProperty("CoursElementsCompetences")]
        public virtual PlansCadres PlansCadres { get; set; }

        [ForeignKey("CompetenceID,DisciplineId,ElementCompetenceQNBR")]
        [InverseProperty("CoursElementsCompetences")]
        public virtual ElementsCompetence ElementsCompetence { get; set; }

        [Required]
        public bool IsPartial
        {
            get
            {
                return PrtlSklInd == "0";
            }
            set
            {
                IsPartial = value;

                PrtlSklInd = IsPartial ? "1" : "0";
            }
        }
    }
}
