using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.Client.Data
{
    [Table("TCRSTMPLT")]
    public partial class Tcrstmplt
    {
        public Tcrstmplt()
        {
            Tcrsreq = new HashSet<Tcrsreq>();
            Tcrssklelem = new HashSet<Tcrssklelem>();
            Tfnlexam = new HashSet<Tfnlexam>();
        }

        [Key]
        [Column("CRS_ID")]
        [StringLength(10)]
        public string CrsId { get; set; }
        [Key]
        [Column("VSN_CDTTM", TypeName = "datetime")]
        public DateTime VsnCdttm { get; set; }
        [Column("PGM_ID")]
        [StringLength(6)]
        public string PgmId { get; set; }
        [Column("CRS_TITLE")]
        [StringLength(50)]
        public string CrsTitle { get; set; }
        [Column("UNITS", TypeName = "decimal(3, 2)")]
        public decimal? Units { get; set; }
        [Column("CRS_DESC", TypeName = "ntext")]
        public string CrsDesc { get; set; }
        [Column("CRS_EDU_INTENT", TypeName = "ntext")]
        public string CrsEduIntent { get; set; }
        [Column("CRS_PDG_INTENT", TypeName = "ntext")]
        public string CrsPdgIntent { get; set; }
        [Column("THEORY_HRS")]
        public int? TheoryHrs { get; set; }
        [Column("PRCT_HRS")]
        public int? PrctHrs { get; set; }
        [Column("HOME_HRS")]
        public int? HomeHrs { get; set; }
        [Column("DPTMNT_APPRV_DT", TypeName = "date")]
        public DateTime? DptmntApprvDt { get; set; }
        [Column("CMTE_APPRV_DT", TypeName = "date")]
        public DateTime? CmteApprvDt { get; set; }
        [Column("BOARD_APPRV_DT", TypeName = "date")]
        public DateTime? BoardApprvDt { get; set; }
        [Column("TRK_UID")]
        [StringLength(7)]
        public string TrkUid { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; }

        [InverseProperty("Tcrstmplt")]
        public virtual ICollection<Tcrsreq> Tcrsreq { get; set; }
        [InverseProperty("Tcrstmplt")]
        public virtual ICollection<Tcrssklelem> Tcrssklelem { get; set; }
        [InverseProperty("Tcrstmplt")]
        public virtual ICollection<Tfnlexam> Tfnlexam { get; set; }
    }
}
