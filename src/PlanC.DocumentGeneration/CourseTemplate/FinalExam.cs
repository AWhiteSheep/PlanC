using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PlanC.DocumentGeneration.CourseTemplate
{
    [Serializable]
    public class FinalExam
    {
        private Collection<FinalExamCriteria>? _criterias = new Collection<FinalExamCriteria>();

        public string? Title { get; set; }

        public decimal? Weight { get; set; }

        public Collection<FinalExamCriteria> Criterias
        {
            get => _criterias ?? (_criterias = new Collection<FinalExamCriteria>());
            set => _criterias = value;
        }
    }
}
