using System;
using System.Collections.Generic;

namespace PlanC.WebApi.Models
{
    public partial class Exam_SkillElement
    {
        public int ExamId { get; set; }
        public string SkillId { get; set; }
        public short SkillElelementSequenceNumber { get; set; }
        public decimal? SkillElementWeight { get; set; }
        public string TrackingUserId { get; set; }

        public ExamInfo Exam { get; set; }
        public SkillElement SkillElement { get; set; }
    }
}
