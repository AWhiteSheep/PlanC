using System;
using System.Collections.Generic;

namespace PlanC.Web.Client.Models2
{
    public partial class Tsklelemcrt
    {
        public string SklId { get; set; }
        public short SklElemSqnbr { get; set; }
        public short SklElemCrtSqnbr { get; set; }
        public string SklElemCrtTitle { get; set; }
        public DateTime RcdCdttm { get; set; }
        public string TrkUid { get; set; }

        public virtual Tsklelem Skl { get; set; }
    }
}
