using System;
using System.Collections.Generic;

namespace PlanC.WebApi.Models
{
    public partial class Tcertexam
    {
        public string CrsId { get; set; }
        public string TchrUid { get; set; }
        public DateTime PlnVsnCdttm { get; set; }
        public string SmstrId { get; set; }
        public int ExamId { get; set; }

        public Exam Exam { get; set; }
    }
}
