using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            RelTablPcrsPcadres = new HashSet<RelTablPcrsPcadres>();
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
        public string Group { get; set; }
        [NotMapped]
        public string _Group {
            get {
                return string.IsNullOrEmpty(Group) ? "Non spécifié" : Group;
            }
        }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; }
        [Column("TRK_UID")]
        [StringLength(7)]
        public string TrkUid { get; set; }

        [Column("CoursePolicy", TypeName = "ntext")]
        public string CoursePolicy { get; set; }
        [Column("PonderationComment", TypeName ="ntext")]
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
        [InverseProperty("PlC")]
        public virtual ICollection<RelTablPcrsPcadres> RelTablPcrsPcadres { get; set; }
        [NotMapped]
        public Collection<string> _MaterielsCours {
            get {
                if(MaterielsCours == null)
                    return new Collection<string>();

                var listMateriel = new Collection<string>();
                foreach(var materiel in MaterielsCours){
                    listMateriel.Add(materiel.Description);
                }
                return listMateriel;
            }
        }
    }
}
