using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PlanC.EntityDataModel
{
    public partial class ExamensCertificatifsNonsFinals
    {
        [Key]
        [Column("CoursID")]
        [StringLength(10)]
        public string CoursId { get; set; }
        [Key]
        [Column("TCHR_UID")]
        [StringLength(7)]
        public string TchrUid { get; set; }
        [Key]
        [Column("PLN_VSN_CDTTM", TypeName = "datetime")]
        public DateTime PlnVsnCdttm { get; set; }
        [Key]
        [Column("SessionID")]
        [StringLength(3)]
        public string SessionId { get; set; }
        [Key]
        [Column("ExamenID")]
        public int ExamenId { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; }
        [Column("TRK_UID")]
        [StringLength(7)]
        public string TrkUid { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(ExamenId))]
        [InverseProperty(nameof(Examens.ExamensCertificatifsNonsFinals))]
        public virtual Examens Examen { get; set; }
        [ForeignKey("CoursId,TchrUid,PlnVsnCdttm,SessionId")]
        [InverseProperty("ExamensCertificatifsNonsFinals")]
        [JsonIgnore]
        public virtual PlansCours PlansCours { get; set; }
    }
}
