using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Text;

namespace PlanC.DocumentGeneration.Common
{
    [Serializable]
    public class Skill
    {
        private Collection<string>? _achievementContexts;
        private Collection<string>? _contentPrecisions;
        private Collection<SkillElement>? _skillElements;

        public string? Title { get; set; }

        public Collection<string> AchievementContexts
        {
            get => _achievementContexts ?? (_achievementContexts = new Collection<string>());
            set => _achievementContexts = value;
        }

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
