using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PlanC.DocumentGeneration.Common
{
    [Serializable]
    public class FinalExam : Exam
    {
        private Collection<FinalExamCriteria>? _criterias;

        public Collection<FinalExamCriteria> Criterias
        {
            get => _criterias ?? (_criterias = new Collection<FinalExamCriteria>());
            set => _criterias = value;
        }
    }
}
