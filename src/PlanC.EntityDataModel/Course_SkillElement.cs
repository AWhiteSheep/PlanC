using System;
using System.Collections.Generic;

namespace PlanC.WebApi.Models
{
    public partial class Course_SkillElement
    {
        public string CourseId { get; set; }
        public DateTime VsnCdttm { get; set; }
        public string SkillId { get; set; }
        public short SkillElementSequenceNumber { get; set; }
        public string IsPartial { get; set; }
        public string TaxonomicLevel { get; set; }

        public SkillElement SkillElement { get; set; }
        public CourseTemplate CourseTemplate { get; set; }
    }
}
