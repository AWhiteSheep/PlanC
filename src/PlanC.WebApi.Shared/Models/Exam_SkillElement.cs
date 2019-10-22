using System;
using System.Collections.Generic;

namespace PlanC.WebApi.Models
{
    public partial class Exam_SkillElement
    {
        public int ExamId { get; set; }
        public string SklId { get; set; }
        public short SklelemSqnbr { get; set; }
        public decimal? SklelemWght { get; set; }

        public Exam Exam { get; set; }
        public SkillElement Skl { get; set; }
    }
}
