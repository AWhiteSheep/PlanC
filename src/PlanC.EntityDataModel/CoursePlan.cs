using System;
using System.Collections.Generic;

namespace PlanC.WebApi.Models
{
    public partial class CoursePlan
    {
        public string CrsId { get; set; }
        public string TchrUid { get; set; }
        public DateTime PlnVsnCdttm { get; set; }
        public string SmstrId { get; set; }
        public string TrackingUserId { get; set; }

        public Semester Smstr { get; set; }
    }
}
