using System;
using System.Collections.Generic;

namespace PlanC.WebApi.Models
{
    public partial class ExamInfo
    {
        public ExamInfo()
        {
            NonFinalCertificativeExams = new HashSet<NonFinalCertificativeExam>();
            Exam_SkillElements = new HashSet<Exam_SkillElement>();
            FinalCertificativeExam = new HashSet<FinalCertificativeExam>();
        }

        public int ExamId { get; set; }
        public string ExamTitle { get; set; }
        public string ExamTyCd { get; set; }
        public decimal? Weight { get; set; }
        public string TrackingUserId { get; set; }

        public ICollection<NonFinalCertificativeExam> NonFinalCertificativeExams { get; set; }
        public ICollection<Exam_SkillElement> Exam_SkillElements { get; set; }
        public ICollection<FinalCertificativeExam> FinalCertificativeExam { get; set; }
    }
}
