using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PlanC.EntityDataModel
{
    public partial class Sessions
    {
        public Sessions()
        {
            PlansCours = new HashSet<PlansCours>();
        }

        [Key]
        [Column("ID")]
        [StringLength(3)]
        public string Id { get; set; }
        [StringLength(50)]
        public string Titre { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Debut { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Fin { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; }
        [Column("TRK_UID")]
        [StringLength(7)]
        public string TrkUid { get; set; }

        [InverseProperty("Session")]
        [IgnoreDataMember]
        [JsonIgnore]
        public virtual ICollection<PlansCours> PlansCours { get; set; }
    }
}
