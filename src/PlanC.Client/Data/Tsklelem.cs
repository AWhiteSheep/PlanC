using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.Client.Data
{
    [Table("TSKLELEM")]
    public partial class Tsklelem
    {
        public Tsklelem()
        {
            Tactelem = new HashSet<Tactelem>();
            Tcrssklelem = new HashSet<Tcrssklelem>();
            Texamsklelem = new HashSet<Texamsklelem>();
            Tsklelemcrt = new HashSet<Tsklelemcrt>();
        }

        [Key]
        [Column("SKL_ID")]
        [StringLength(4)]
        public string SklId { get; set; }
        [Key]
        [Column("SKLELEM_SQNBR")]
        public short SklelemSqnbr { get; set; }
        [Column("SKLELEM_TITLE")]
        [StringLength(255)]
        public string SklelemTitle { get; set; }
        [Column("SKLELEM_DESC", TypeName = "ntext")]
        public string SklelemDesc { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; }
        [Column("TRK_UID")]
        [StringLength(7)]
        public string TrkUid { get; set; }

        [ForeignKey(nameof(SklId))]
        [InverseProperty(nameof(Tskl.Tsklelem))]
        public virtual Tskl Skl { get; set; }
        [InverseProperty("Skl")]
        public virtual ICollection<Tactelem> Tactelem { get; set; }
        [InverseProperty("Skl")]
        public virtual ICollection<Tcrssklelem> Tcrssklelem { get; set; }
        [InverseProperty("Skl")]
        public virtual ICollection<Texamsklelem> Texamsklelem { get; set; }
        [InverseProperty("Skl")]
        public virtual ICollection<Tsklelemcrt> Tsklelemcrt { get; set; }
    }
}
