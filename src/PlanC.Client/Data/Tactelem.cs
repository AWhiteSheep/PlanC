using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.Client.Data
{
    [Table("TACTELEM")]
    public partial class Tactelem
    {
        [Key]
        [Column("SKLELEM_SQNBR")]
        public short SklelemSqnbr { get; set; }
        [Key]
        [Column("SKL_ID")]
        [StringLength(4)]
        public string SklId { get; set; }
        [Key]
        [Column("CRS_ID")]
        [StringLength(10)]
        public string CrsId { get; set; }
        [Key]
        [Column("TCHR_UID")]
        [StringLength(7)]
        public string TchrUid { get; set; }
        [Key]
        [Column("PLN_VSN_CDTTM", TypeName = "datetime")]
        public DateTime PlnVsnCdttm { get; set; }
        [Key]
        [Column("SMSTR_ID")]
        [StringLength(3)]
        public string SmstrId { get; set; }
        [Key]
        [Column("ACTVT_SQNBR")]
        public short ActvtSqnbr { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; }
        [Column("TRK_UID")]
        [StringLength(7)]
        public string TrkUid { get; set; }

        [ForeignKey("SklId,SklelemSqnbr")]
        [InverseProperty(nameof(Tsklelem.Tactelem))]
        public virtual Tsklelem Skl { get; set; }
        [ForeignKey("CrsId,TchrUid,PlnVsnCdttm,SmstrId,ActvtSqnbr")]
        [InverseProperty("Tactelem")]
        public virtual Tcrsactvt Tcrsactvt { get; set; }
    }
}
