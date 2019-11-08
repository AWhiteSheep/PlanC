using System;
using System.Collections.Generic;

namespace PlanC.WebApi.Models
{
    public partial class FinalCertificativeExam
    {
        public string CourseId { get; set; }
        public DateTime VsnCdttm { get; set; }
        public int ExamId { get; set; }
        public string TrackingUserId { get; set; }

        public ExamInfo Exam { get; set; }
        public CourseTemplate Tcrstmplt { get; set; }
    }
}
