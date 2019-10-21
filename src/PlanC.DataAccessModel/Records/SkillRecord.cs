using PlanC.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PlanC.DataAccessModel.Records
{
    public class SkillRecord
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Attd { get; set; }
        public string TrackingUserId { get; set; }
        public DateTime? Timestamp { get; set; }

        public virtual ICollection<SkillElementRecord> Tsklelem { get; set; }
    }
}
