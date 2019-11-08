using System;
using System.Collections.Generic;

namespace PlanC.WebApi.Models
{
    public partial class Skill
    {
        public Skill()
        {
            Tsklcntxt = new HashSet<SkillAchievementContext>();
            Tsklelem = new HashSet<SkillElement>();
        }

        public string Id { get; set; }
        public string StudyProgramId { get; set; }
        public string Title { get; set; }
        //TODO: Nom de la prop
        public string AsscAttd { get; set; }
        public string TrackingUserId { get; set; }
        //public DateTime? RcdCdttm { get; set; }

        public Tpgm StudyProgram { get; set; }
        public ICollection<SkillAchievementContext> Tsklcntxt { get; set; }
        public ICollection<SkillElement> Tsklelem { get; set; }
    }
}
