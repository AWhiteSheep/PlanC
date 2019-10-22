using System;
using System.Collections.Generic;

namespace PlanC.WebApi.Models
{
    public partial class Tfnlexam
    {
        public string CrsId { get; set; }
        public DateTime VsnCdttm { get; set; }
        public int ExamId { get; set; }

        public Exam Exam { get; set; }
        public CourseTemplate Tcrstmplt { get; set; }
    }
}
