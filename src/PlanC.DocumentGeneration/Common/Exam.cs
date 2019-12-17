using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PlanC.DocumentGeneration.Common
{
    [Serializable]
    public class Exam
    {
        public string? Title { get; set; }

        public decimal? Weight { get; set; }
    }
}
