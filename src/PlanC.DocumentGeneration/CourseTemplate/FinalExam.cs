using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PlanC.DocumentGeneration.CourseTemplate
{
    [Serializable]
    public class FinalExam
    {
        public string Title { get; set; }

        public decimal Weight { get; set; }

        public Collection<FinalExamCriteria> Criterias { get; set; }
    }
}
