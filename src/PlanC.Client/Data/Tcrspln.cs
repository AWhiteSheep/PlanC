using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.Client.Data
{
    [Table("TCRSPLN")]
    public partial class Tcrspln
    {
        public Tcrspln()
        {
            Tcertexam = new HashSet<Tcertexam>();
            Tcrsactvt = new HashSet<Tcrsactvt>();
            Tcrsmtrl = new HashSet<Tcrsmtrl>();
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
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; }
        [Column("TRK_UID")]
        [StringLength(7)]
        public string TrkUid { get; set; }

        [ForeignKey(nameof(SmstrId))]
        [InverseProperty(nameof(Tsmstr.Tcrspln))]
        public virtual Tsmstr Smstr { get; set; }
        [InverseProperty("Tcrspln")]
        public virtual ICollection<Tcertexam> Tcertexam { get; set; }
        [InverseProperty("Tcrspln")]
        public virtual ICollection<Tcrsactvt> Tcrsactvt { get; set; }
        [InverseProperty("Tcrspln")]
        public virtual ICollection<Tcrsmtrl> Tcrsmtrl { get; set; }
    }
}
