using System;
using System.Collections.Generic;
using System.Text;

namespace PlanC.DocumentGeneration.Common
{
    [Serializable]
    public class Prerequisite
    {
        public PrerequisiteType? PrerequisiteType { get; set; }

        public string? CourseId { get; set; }

        public string? CourseTitle { get; set; }
    }
}
