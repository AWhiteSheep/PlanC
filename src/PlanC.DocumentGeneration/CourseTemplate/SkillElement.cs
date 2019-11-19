using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PlanC.DocumentGeneration.CourseTemplate
{
    [Serializable]
    public class SkillElement
    {
        public string Title { get; set; }

        public Collection<string> Criterias { get; set; }

        public Collection<string> ContentPrecisions { get; set; }
    }
}
