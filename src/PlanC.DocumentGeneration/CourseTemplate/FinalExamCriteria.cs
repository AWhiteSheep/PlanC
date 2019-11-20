using System;
using System.Collections.Generic;
using System.Text;

namespace PlanC.DocumentGeneration.CourseTemplate
{
    [Serializable]
    public class FinalExamCriteria
    {
        public string? SkillElementId { get; set; }

        public string? Description { get; set; }

        public decimal? Weight { get; set; }
    }
}
