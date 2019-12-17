using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PlanC.DocumentGeneration.Common
{
    [Serializable]
    public class SkillElement
    {
        private Collection<string>? _criterias;
        private Collection<string>? _contentPrecisions;

        public string? Title { get; set; }

        public bool? IsPartiallyAchieved { get; set; }

        public Collection<string> Criterias
        {
            get => _criterias ?? (_criterias = new Collection<string>());
            set => _criterias = value;
        }
        public Collection<string> ContentPrecisions
        {
            get => _contentPrecisions ?? (_contentPrecisions = new Collection<string>());
            set => _contentPrecisions = value;
        }
    }
}
