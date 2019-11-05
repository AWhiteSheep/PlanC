using System;
using System.Collections.Generic;

namespace PlanC.WebApi.Models
{
    public partial class Exam
    {
        public Exam()
        {
            Tcertexam = new HashSet<Tcertexam>();
            Texamsklelem = new HashSet<Exam_SkillElement>();
            Tfnlexam = new HashSet<Tfnlexam>();
        }

        public int ExamId { get; set; }
        public string ExamTyCd { get; set; }
        public decimal? ExamWght { get; set; }

        public ICollection<Tcertexam> Tcertexam { get; set; }
        public ICollection<Exam_SkillElement> Texamsklelem { get; set; }
        public ICollection<Tfnlexam> Tfnlexam { get; set; }
    }
}
