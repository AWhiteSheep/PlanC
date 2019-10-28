using System;
using System.Collections.Generic;

namespace BlazorApp1.Data
{
    public partial class Tcertexam
    {
        public string CrsId { get; set; }
        public string TchrUid { get; set; }
        public DateTime PlnVsnCdttm { get; set; }
        public string SmstrId { get; set; }
        public int ExamId { get; set; }

        public virtual Texam Exam { get; set; }
    }
}
