using System;
using System.Collections.Generic;

namespace PlanC.WebApi.Models
{
    public partial class Code
    {
        public string CdTy { get; set; }
        public string Cd { get; set; }
        public string CdDesc { get; set; }
        public string TrackingUserId { get; set; }
        public DateTime? RcdCdttm { get; set; }

        public CodeType CdTyNavigation { get; set; }
    }
}
