using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.EntityDataModel
{
    public partial class PlansCours
    {
        public PlansCours()
        {
            CoursActivite = new HashSet<CoursActivite>();
            ExamensCertificatifsNonsFinals = new HashSet<ExamensCertificatifsNonsFinals>();
            MaterielsCours = new HashSet<MaterielsCours>();
        }

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
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; }
        [Column("TRK_UID")]
        [StringLength(7)]
        public string TrkUid { get; set; }

        [Column("CoursePolicy", TypeName = "ntext")]
        public string CoursePolicy { get; set; }
        [Column("PonderationComment", TypeName = "ntext")]
        public string PonderationComment { get; set; }


        [ForeignKey(nameof(SessionId))]
        [InverseProperty(nameof(Sessions.PlansCours))]
        public virtual Sessions Session { get; set; }
        [InverseProperty("PlansCours")]
        public virtual ICollection<CoursActivite> CoursActivite { get; set; }
        [InverseProperty("PlansCours")]
        public virtual ICollection<ExamensCertificatifsNonsFinals> ExamensCertificatifsNonsFinals { get; set; }
        [InverseProperty("PlansCours")]
        public virtual ICollection<MaterielsCours> MaterielsCours { get; set; }
    }
}
