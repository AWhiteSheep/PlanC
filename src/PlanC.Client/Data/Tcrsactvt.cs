using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.Client.Data
{
    [Table("TCRSACTVT")]
    public partial class Tcrsactvt
    {
        public Tcrsactvt()
        {
            Tactelem = new HashSet<Tactelem>();
        }

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
        [Column("ACTVT_LGNTH")]
        public short? ActvtLgnth { get; set; }
        [Column("ACTVT_DESC", TypeName = "ntext")]
        public string ActvtDesc { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; }
        [Column("TRK_UID")]
        [StringLength(7)]
        public string TrkUid { get; set; }

        [ForeignKey("CrsId,TchrUid,PlnVsnCdttm,SmstrId")]
        [InverseProperty("Tcrsactvt")]
        public virtual Tcrspln Tcrspln { get; set; }
        [InverseProperty("Tcrsactvt")]
        public virtual ICollection<Tactelem> Tactelem { get; set; }
    }
}
