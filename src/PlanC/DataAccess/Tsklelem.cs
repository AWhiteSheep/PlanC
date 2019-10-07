using System;
using System.Collections.Generic;

namespace PlanC.DataAccess
{
    public partial class Tsklelem
    {
        public Tsklelem()
        {
            Tskltmplt = new HashSet<Tskltmplt>();
        }

        public string SklId { get; set; }
        public short SklElemSqnbr { get; set; }
        public string SklElemTitle { get; set; }
        public string SklElemDesc { get; set; }
        public string TrackingUid { get; set; }
        public DateTime? RecordCdttm { get; set; }

        public virtual Tskl Skl { get; set; }
        public virtual ICollection<Tskltmplt> Tskltmplt { get; set; }
    }
}
