using System;
using System.Collections.Generic;

namespace PlanC.WebApi.Models
{
    public partial class Skill
    {
        public Skill()
        {
            Tsklcntxt = new HashSet<Tsklcntxt>();
            Tsklelem = new HashSet<SkillElement>();
        }

        public string SklId { get; set; }
        public string PgmId { get; set; }
        public string SklTitle { get; set; }
        public string AsscAttd { get; set; }
        public string TrkUid { get; set; }
        public DateTime? RcdCdttm { get; set; }

        public Tpgm Pgm { get; set; }
        public ICollection<Tsklcntxt> Tsklcntxt { get; set; }
        public ICollection<SkillElement> Tsklelem { get; set; }
    }
}
