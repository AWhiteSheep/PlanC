using System;
using System.Collections.Generic;

namespace BlazorApp1.Data
{
    public partial class Tfnlexam
    {
        public string CrsId { get; set; }
        public DateTime VsnCdttm { get; set; }
        public int ExamId { get; set; }

        public virtual Texam Exam { get; set; }
        public virtual Tcrstmplt Tcrstmplt { get; set; }
    }
}
