using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.Client.Data
{
    [Table("TCRSMTRL")]
    public partial class Tcrsmtrl
    {
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
        [Column("CRS_MTRL_SQNBR")]
        public short CrsMtrlSqnbr { get; set; }
        [Column("CRS_MTRL_DESC")]
        [StringLength(255)]
        public string CrsMtrlDesc { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; }
        [Column("TRK_UID")]
        [StringLength(7)]
        public string TrkUid { get; set; }

        [ForeignKey("CrsId,TchrUid,PlnVsnCdttm,SmstrId")]
        [InverseProperty("Tcrsmtrl")]
        public virtual Tcrspln Tcrspln { get; set; }
    }
}
