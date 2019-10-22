using System;
using System.Collections.Generic;

namespace BlazorApp1.Data
{
    public partial class Texam
    {
        public Texam()
        {
            Tcertexam = new HashSet<Tcertexam>();
            Texamsklelem = new HashSet<Texamsklelem>();
            Tfnlexam = new HashSet<Tfnlexam>();
        }

        public int ExamId { get; set; }
        public string ExamTyCd { get; set; }
        public decimal? ExamWght { get; set; }

        public virtual ICollection<Tcertexam> Tcertexam { get; set; }
        public virtual ICollection<Texamsklelem> Texamsklelem { get; set; }
        public virtual ICollection<Tfnlexam> Tfnlexam { get; set; }
    }
}
