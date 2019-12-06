using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.EntityDataModel
{
    public partial class Examens
    {
        public Examens()
        {
            ExamensCertificatifsNonsFinals = new HashSet<ExamensCertificatifsNonsFinals>();
            ExamensElementsCompetences = new HashSet<ExamensElementsCompetences>();
            ExamensFinalsCertificatifs = new HashSet<ExamensFinalsCertificatifs>();
        }

        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(2)]
        public string TypeExamenCode { get; set; }
        [StringLength(150)]
        public string Qualification { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal? PoidExamen { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; }
        [Column("TRK_UID")]
        [StringLength(7)]
        public string TrkUid { get; set; }

        [InverseProperty("Examen")]
        public virtual ICollection<ExamensCertificatifsNonsFinals> ExamensCertificatifsNonsFinals { get; set; }
        [InverseProperty("Examen")]
        public virtual ICollection<ExamensElementsCompetences> ExamensElementsCompetences { get; set; }
        [InverseProperty("Examen")]
        public virtual ICollection<ExamensFinalsCertificatifs> ExamensFinalsCertificatifs { get; set; }
    }
}
