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
        private Collection<string>? _contentPrecisions = new Collection<string>();
        private Collection<SkillElement>? _skillElements = new Collection<SkillElement>();

        public string? Title { get; set; }

        public Collection<string> AchievementContexts { get; set; } = new Collection<string>();

        public Collection<string> ContentPrecisions
        {
            get => _contentPrecisions ?? (_contentPrecisions = new Collection<string>());
            set => _contentPrecisions = value;
        }
        public Collection<SkillElement> SkillElements
        {
            get => _skillElements ?? (_skillElements = new Collection<SkillElement>());
            set => _skillElements = value;
        }
    }
}
