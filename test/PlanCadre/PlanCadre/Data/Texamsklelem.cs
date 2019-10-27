using System;
using System.Collections.Generic;

namespace PlanCadre.Data
{
    public partial class Texamsklelem
    {
        public int ExamId { get; set; }
        public string SklId { get; set; }
        public short SklelemSqnbr { get; set; }
        public decimal? SklelemWght { get; set; }

        public virtual Texam Exam { get; set; }
        public virtual Tsklelem Skl { get; set; }
    }
}
