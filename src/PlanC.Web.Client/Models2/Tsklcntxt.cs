using System;
using System.Collections.Generic;

namespace PlanC.Web.Client.Models2
{
    public partial class Tsklcntxt
    {
        public string SklId { get; set; }
        public short SklCntxtSqnbr { get; set; }
        public string SklCntxtTitle { get; set; }
        public DateTime? RcdCdttm { get; set; }
        public string TrkUid { get; set; }

        public virtual Tskl Skl { get; set; }
    }
}
