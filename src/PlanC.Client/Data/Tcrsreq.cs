using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.Client.Data
{
    [Table("TCRSREQ")]
    public partial class Tcrsreq
    {
        [Key]
        [Column("CRS_ID")]
        [StringLength(10)]
        public string CrsId { get; set; }
        [Key]
        [Column("VSN_CDTTM", TypeName = "datetime")]
        public DateTime VsnCdttm { get; set; }
        [Key]
        [Column("REQ_CRS_ID")]
        [StringLength(10)]
        public string ReqCrsId { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; }
        [Column("CRS_REQ_TY_CD")]
        [StringLength(2)]
        public string CrsReqTyCd { get; set; }
        [Column("TRK_UID")]
        [StringLength(7)]
        public string TrkUid { get; set; }

        [ForeignKey("CrsId,VsnCdttm")]
        [InverseProperty("Tcrsreq")]
        public virtual Tcrstmplt Tcrstmplt { get; set; }
    }
}
