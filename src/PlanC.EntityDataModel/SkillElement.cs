using System;
using System.Collections.Generic;

namespace PlanC.WebApi.Models
{
    public partial class SkillElement
    {
        public SkillElement()
        {
            Tcrssklelem = new HashSet<Course_SkillElement>();
            Texamsklelem = new HashSet<Exam_SkillElement>();
        }

        public string SkillId { get; set; }
        public short SequenceNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TrackingUserId { get; set; }
        //public DateTime? RcdCdttm { get; set; }

        public Skill Skl { get; set; }
        public ICollection<Course_SkillElement> Tcrssklelem { get; set; }
        public ICollection<Exam_SkillElement> Texamsklelem { get; set; }
    }
}
