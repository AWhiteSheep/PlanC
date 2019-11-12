using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.Client.Data
{
    [Table("TROLE")]
    public partial class Trole
    {
        public Trole()
        {
            Tuserrole = new HashSet<Tuserrole>();
        }

        [Key]
        [Column("ROLE_ID")]
        public int RoleId { get; set; }
        [Column("ROLE_NM")]
        [StringLength(50)]
        public string RoleNm { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; }

        [InverseProperty("Role")]
        public virtual ICollection<Tuserrole> Tuserrole { get; set; }
    }
}
