using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.Client.Data
{
    [Table("TUSER")]
    public partial class Tuser
    {
        public Tuser()
        {
            Tuseravl = new HashSet<Tuseravl>();
            Tuserrole = new HashSet<Tuserrole>();
        }

        [Key]
        [Column("UID")]
        [StringLength(7)]
        public string Uid { get; set; }
        [Column("DPTMNT_ID")]
        public int? DptmntId { get; set; }
        [Column("GVN_NM")]
        [StringLength(50)]
        public string GvnNm { get; set; }
        [Column("SNM")]
        [StringLength(50)]
        public string Snm { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; }

        [ForeignKey(nameof(DptmntId))]
        [InverseProperty(nameof(Tdptmnt.Tuser))]
        public virtual Tdptmnt Dptmnt { get; set; }
        [InverseProperty("U")]
        public virtual ICollection<Tuseravl> Tuseravl { get; set; }
        [InverseProperty("U")]
        public virtual ICollection<Tuserrole> Tuserrole { get; set; }
    }
}
