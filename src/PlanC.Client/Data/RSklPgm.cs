using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.Client.Data
{
    [Table("R_SKL_PGM")]
    public partial class RSklPgm
    {
        [Key]
        [Column("PGM_ID")]
        [StringLength(6)]
        public string PgmId { get; set; }
        [Key]
        [Column("DPTMNT_ID")]
        public int DptmntId { get; set; }
        [Key]
        [Column("SKL_ID")]
        [StringLength(4)]
        public string SklId { get; set; }

        [ForeignKey(nameof(SklId))]
        [InverseProperty(nameof(Tskl.RSklPgm))]
        public virtual Tskl Skl { get; set; }
        [ForeignKey("PgmId,DptmntId")]
        [InverseProperty("RSklPgm")]
        public virtual Tpgm Tpgm { get; set; }
    }
}
