using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.Client.Data
{
    [Table("TSKLCNTXT")]
    public partial class Tsklcntxt
    {
        [Key]
        [Column("SKL_ID")]
        [StringLength(4)]
        public string SklId { get; set; }
        [Key]
        [Column("SKL_CNTXT_SQNBR")]
        public short SklCntxtSqnbr { get; set; }
        [Column("SKL_CNTXT_TITLE")]
        [StringLength(512)]
        public string SklCntxtTitle { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; }
        [Column("TRK_UID")]
        [StringLength(7)]
        public string TrkUid { get; set; }

        [ForeignKey(nameof(SklId))]
        [InverseProperty(nameof(Tskl.Tsklcntxt))]
        public virtual Tskl Skl { get; set; }
    }
}
