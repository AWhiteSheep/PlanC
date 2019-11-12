using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.Client.Data
{
    [Table("TCRSSKLELEM")]
    public partial class Tcrssklelem
    {
        [Key]
        [Column("CRS_ID")]
        [StringLength(10)]
        public string CrsId { get; set; }
        [Key]
        [Column("VSN_CDTTM", TypeName = "datetime")]
        public DateTime VsnCdttm { get; set; }
        [Key]
        [Column("SKL_ID")]
        [StringLength(4)]
        public string SklId { get; set; }
        [Key]
        [Column("SKLELEM_SQNBR")]
        public short SklelemSqnbr { get; set; }
        [Column("PRTL_SKL_IND")]
        [StringLength(1)]
        public string PrtlSklInd { get; set; }
        [Column("TXNMY_CD")]
        [StringLength(2)]
        public string TxnmyCd { get; set; }
        [Column("ADDTNL_DESC", TypeName = "ntext")]
        public string AddtnlDesc { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; }
        [Column("TRK_UID")]
        [StringLength(7)]
        public string TrkUid { get; set; }

        [ForeignKey("SklId,SklelemSqnbr")]
        [InverseProperty(nameof(Tsklelem.Tcrssklelem))]
        public virtual Tsklelem Skl { get; set; }
        [ForeignKey("CrsId,VsnCdttm")]
        [InverseProperty("Tcrssklelem")]
        public virtual Tcrstmplt Tcrstmplt { get; set; }
    }
}
