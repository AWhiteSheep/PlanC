using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.Client.Data
{
    [Table("TSKLELEMCRT")]
    public partial class Tsklelemcrt
    {
        [Key]
        [Column("SKL_ID")]
        [StringLength(4)]
        public string SklId { get; set; }
        [Key]
        [Column("SKL_ELEM_SQNBR")]
        public short SklElemSqnbr { get; set; }
        [Key]
        [Column("SKL_ELEM_CRT_SQNBR")]
        public short SklElemCrtSqnbr { get; set; }
        [Column("SKL_ELEM_CRT_TITLE")]
        [StringLength(255)]
        public string SklElemCrtTitle { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime RcdCdttm { get; set; }
        [Required]
        [Column("TRK_UID")]
        [StringLength(7)]
        public string TrkUid { get; set; }

        [ForeignKey("SklId,SklElemSqnbr")]
        [InverseProperty(nameof(Tsklelem.Tsklelemcrt))]
        public virtual Tsklelem Skl { get; set; }
    }
}
