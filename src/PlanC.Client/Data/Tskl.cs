using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.Client.Data
{
    [Table("TSKL")]
    public partial class Tskl
    {
        public Tskl()
        {
            RSklPgm = new HashSet<RSklPgm>();
            Tsklcntxt = new HashSet<Tsklcntxt>();
            Tsklelem = new HashSet<Tsklelem>();
        }

        [Key]
        [Column("SKL_ID")]
        [StringLength(4)]
        public string SklId { get; set; }
        [Column("SKL_TITLE")]
        [StringLength(200)]
        public string SklTitle { get; set; }
        [Column("ASSC_ATTD", TypeName = "ntext")]
        public string AsscAttd { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; }
        [Column("TRK_UID")]
        [StringLength(7)]
        public string TrkUid { get; set; }

        [InverseProperty("Skl")]
        public virtual ICollection<RSklPgm> RSklPgm { get; set; }
        [InverseProperty("Skl")]
        public virtual ICollection<Tsklcntxt> Tsklcntxt { get; set; }
        [InverseProperty("Skl")]
        public virtual ICollection<Tsklelem> Tsklelem { get; set; }
    }
}
