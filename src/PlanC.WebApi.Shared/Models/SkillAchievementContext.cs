using System;
using System.Collections.Generic;

namespace PlanC.WebApi.Models
{
    public partial class SkillAchievementContext
    {
        public string SkillId { get; set; }
        public short SequenceNumber { get; set; }
        public string Description { get; set; }
        public string TrackingUserId { get; set; }
        //public DateTime? RcdCdttm { get; set; }

        public Skill Skl { get; set; }
    }
}
