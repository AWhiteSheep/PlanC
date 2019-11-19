using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Text;

namespace PlanC.DocumentGeneration.CourseTemplate
{
    [Serializable]
    public class Skill
    {
        public string Title { get; set; }
        
        public Collection<string> AchievementContexts { get; set; }

        public Collection<string> ContentPrecisions { get; set; }

        public Collection<SkillElement> SkillElements { get; set; }
    }
}
