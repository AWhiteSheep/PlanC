using System;
using System.Collections.Generic;

namespace PlanC.DataAccess
{
    public partial class Tskl
    {
        public Tskl()
        {
            Tsklelem = new HashSet<Tsklelem>();
        }

        public string SklId { get; set; }
        public string SklTitle { get; set; }
        public string Attd { get; set; }
        public string TrackingUid { get; set; }
        public DateTime? RecordCdttm { get; set; }

        public virtual ICollection<Tsklelem> Tsklelem { get; set; }
    }
}
