using System;
using System.Collections.Generic;

namespace PlanC.WebApi.Models
{
    public partial class SkillElement
    {
        public SkillElement()
        {
            Tcrssklelem = new HashSet<Tcrssklelem>();
            Texamsklelem = new HashSet<Exam_SkillElement>();
        }

        public string SklId { get; set; }
        public short SklelemSqnbr { get; set; }
        public string SklelemTitle { get; set; }
        public string SklelemDesc { get; set; }
        public string TrkUid { get; set; }
        public DateTime? RcdCdttm { get; set; }

        public Skill Skl { get; set; }
        public ICollection<Tcrssklelem> Tcrssklelem { get; set; }
        public ICollection<Exam_SkillElement> Texamsklelem { get; set; }
    }
}
