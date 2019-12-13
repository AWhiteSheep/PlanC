using PlanC.DocumentGeneration.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace PlanC.DocumentGeneration.CourseTemplate
{
    [Serializable]
    //[XmlRoot(Namespace = XmlConstants.CourseTemplateNamespace)]
    public class CourseTemplate
    {
        private Collection<Skill>? _skills = new Collection<Skill>();

        public string? CourseTitle { get; set; }

        public string? CourseId { get; set; }

        public string? CourseDescription { get; set; }

        public TimeDistribution? TimeDistribution { get; set; }

        public decimal? UnitsCount { get; set; }

        public string? PedagogicalIntent { get; set; }

        public string? EducativeIntent { get; set; }

        public Collection<Skill> Skills
        {
            get => _skills ?? (_skills = new Collection<Skill>());
            set => _skills = value;
        }
    }
}
