using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.Client.Data
{
    [Table("TSMSTR")]
    public partial class Tsmstr
    {
        public Tsmstr()
        {
            Tcrspln = new HashSet<Tcrspln>();
        }

        [Key]
        [Column("SMSTR_ID")]
        [StringLength(3)]
        public string SmstrId { get; set; }
        [Column("SMSTR_DESC")]
        [StringLength(50)]
        public string SmstrDesc { get; set; }
        [Column("SMSTR_SDT", TypeName = "date")]
        public DateTime? SmstrSdt { get; set; }
        [Column("SMSTR_NDT", TypeName = "date")]
        public DateTime? SmstrNdt { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; }
        [Column("TRK_UID")]
        [StringLength(7)]
        public string TrkUid { get; set; }

        [InverseProperty("Smstr")]
        public virtual ICollection<Tcrspln> Tcrspln { get; set; }
    }
}
