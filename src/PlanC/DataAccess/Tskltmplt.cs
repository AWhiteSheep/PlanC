using System;
using System.Collections.Generic;

namespace PlanC.DataAccess
{
    public partial class Tskltmplt
    {
        public string CrsId { get; set; }
        public short SklElemSqnbr { get; set; }
        public string SklId { get; set; }

        public virtual TcrsTmplt Crs { get; set; }
        public virtual Tsklelem Skl { get; set; }
    }
}
