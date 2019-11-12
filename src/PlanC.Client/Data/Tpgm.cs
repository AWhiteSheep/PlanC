using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.Client.Data
{
    [Table("TPGM")]
    public partial class Tpgm
    {
        public Tpgm()
        {
            RSklPgm = new HashSet<RSklPgm>();
        }

        [Key]
        [Column("PGM_ID")]
        [StringLength(6)]
        public string PgmId { get; set; }
        [Key]
        [Column("DPTMNT_ID")]
        public int DptmntId { get; set; }
        [Column("PGM_TITLE")]
        [StringLength(50)]
        public string PgmTitle { get; set; }
        [Column("PGM_DESC", TypeName = "ntext")]
        public string PgmDesc { get; set; }
        [Column("PGM_PDF", TypeName = "ntext")]
        public string PgmPdf { get; set; }
        [Column("PMG_IMG")]
        public string PmgImg { get; set; }
        [Column("PGM_TY_CD")]
        [StringLength(2)]
        public string PgmTyCd { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; }
        [Column("TRK_UID")]
        [StringLength(7)]
        public string TrkUid { get; set; }

        [ForeignKey(nameof(DptmntId))]
        [InverseProperty(nameof(Tdptmnt.Tpgm))]
        public virtual Tdptmnt Dptmnt { get; set; }
        [ForeignKey(nameof(PgmTyCd))]
        [InverseProperty(nameof(Tcdty.Tpgm))]
        public virtual Tcdty PgmTyCdNavigation { get; set; }
        [InverseProperty("Tpgm")]
        public virtual ICollection<RSklPgm> RSklPgm { get; set; }
    }
}
