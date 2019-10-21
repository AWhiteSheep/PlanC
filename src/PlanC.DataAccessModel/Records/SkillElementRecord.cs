using System;
using System.Collections.Generic;

namespace PlanC.DataAccessModel.Records
{
    public partial class SkillElementRecord
    {
        public string Id { get; set; }
        public short SklElemSqnbr { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TrackingUserId { get; set; }
        public DateTime? TimeStamp { get; set; }

        public virtual SkillRecord Skl { get; set; }
    }
}
