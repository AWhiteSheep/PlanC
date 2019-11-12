using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.Client.Data
{
    [Table("TUSERROLE")]
    public partial class Tuserrole
    {
        [Key]
        [Column("UID")]
        [StringLength(7)]
        public string Uid { get; set; }
        [Key]
        [Column("ROLE_ID")]
        public int RoleId { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; }

        [ForeignKey(nameof(RoleId))]
        [InverseProperty(nameof(Trole.Tuserrole))]
        public virtual Trole Role { get; set; }
        [ForeignKey(nameof(Uid))]
        [InverseProperty(nameof(Tuser.Tuserrole))]
        public virtual Tuser U { get; set; }
    }
}
