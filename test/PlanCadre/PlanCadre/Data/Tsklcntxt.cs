using System;
using System.Collections.Generic;

namespace PlanCadre.Data
{
    public partial class Tsklcntxt
    {
        public string SklId { get; set; }
        public short SklCntxtSqnbr { get; set; }
        public string SklCntxtDesc { get; set; }
        public string TrkUid { get; set; }
        public DateTime? RcdCdttm { get; set; }

        public virtual Tskl Skl { get; set; }
    }
}
