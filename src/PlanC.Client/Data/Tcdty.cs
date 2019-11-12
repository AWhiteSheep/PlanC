using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.Client.Data
{
    [Table("TCDTY")]
    public partial class Tcdty
    {
        public Tcdty()
        {
            Tpgm = new HashSet<Tpgm>();
        }

        [Key]
        [Column("CD_TY")]
        [StringLength(2)]
        public string CdTy { get; set; }
        [Column("CD_TY_DESC")]
        [StringLength(250)]
        public string CdTyDesc { get; set; }
        [Column("TRK_UID")]
        [StringLength(7)]
        public string TrkUid { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; }

        [InverseProperty("PgmTyCdNavigation")]
        public virtual ICollection<Tpgm> Tpgm { get; set; }
    }
}
