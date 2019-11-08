using System;
using System.Collections.Generic;

namespace PlanC.WebApi.Models
{
    public partial class NonFinalCertificativeExam
    {
        public string CourseId { get; set; }
        public string TeacherUserId { get; set; }
        public DateTime PlnVsnCdttm { get; set; }
        public string SemesterId { get; set; }
        public int ExamId { get; set; }
        public string TrackingUserId { get; set; }


        public ExamInfo Exam { get; set; }
    }
}
