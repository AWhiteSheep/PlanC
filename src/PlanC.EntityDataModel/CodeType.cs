using System;
using System.Collections.Generic;

namespace PlanC.WebApi.Models
{
    public partial class CodeType
    {
        public CodeType()
        {
            Tcd = new HashSet<Code>();
        }

        public string CdTy { get; set; }
        public string CdTyDesc { get; set; }
        public string TrackingUserId { get; set; }
        public DateTime? RcdCdttm { get; set; }

        public ICollection<Code> Tcd { get; set; }
    }
}
