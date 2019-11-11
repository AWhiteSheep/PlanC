using System;
using System.Collections.Generic;

namespace PlanC.Web.Client.Models2
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
        public string ExamTitle { get; set; }
        public decimal? ExamWght { get; set; }
        public DateTime? RcdCdttm { get; set; }
        public string TrkUid { get; set; }

        public virtual ICollection<Tcertexam> Tcertexam { get; set; }
        public virtual ICollection<Texamsklelem> Texamsklelem { get; set; }
        public virtual ICollection<Tfnlexam> Tfnlexam { get; set; }
    }
}
