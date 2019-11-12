using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.Client.Data
{
    [Table("TDPTMNT")]
    public partial class Tdptmnt
    {
        public Tdptmnt()
        {
            Tpgm = new HashSet<Tpgm>();
            Tuser = new HashSet<Tuser>();
        }

        [Key]
        [Column("DPTMNT_ID")]
        public int DptmntId { get; set; }
        [Column("DPTMNT_TITLE")]
        [StringLength(250)]
        public string DptmntTitle { get; set; }
        [Column("DPTMNT_PLCY", TypeName = "ntext")]
        public string DptmntPlcy { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; }
        [Column("TRK_UID")]
        [StringLength(7)]
        public string TrkUid { get; set; }

        [InverseProperty("Dptmnt")]
        public virtual ICollection<Tpgm> Tpgm { get; set; }
        [InverseProperty("Dptmnt")]
        public virtual ICollection<Tuser> Tuser { get; set; }
    }
}
