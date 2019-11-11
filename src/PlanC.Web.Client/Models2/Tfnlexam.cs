using System;
using System.Collections.Generic;

namespace PlanC.Web.Client.Models2
{
    public partial class Tfnlexam
    {
        public string CrsId { get; set; }
        public DateTime VsnCdttm { get; set; }
        public int ExamId { get; set; }
        public DateTime? RcdCdttm { get; set; }
        public string TrkUid { get; set; }

        public virtual Texam Exam { get; set; }
        public virtual Tcrstmplt Tcrstmplt { get; set; }
    }
}
