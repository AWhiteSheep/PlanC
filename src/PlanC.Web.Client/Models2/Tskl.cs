using System;
using System.Collections.Generic;

namespace PlanC.Web.Client.Models2
{
    public partial class Tskl
    {
        public Tskl()
        {
            Tsklcntxt = new HashSet<Tsklcntxt>();
            Tsklelem = new HashSet<Tsklelem>();
        }

        public string SklId { get; set; }
        public string PgmId { get; set; }
        public string SklTitle { get; set; }
        public string AsscAttd { get; set; }
        public DateTime? RcdCdttm { get; set; }
        public string TrkUid { get; set; }

        public virtual Tpgm Pgm { get; set; }
        public virtual ICollection<Tsklcntxt> Tsklcntxt { get; set; }
        public virtual ICollection<Tsklelem> Tsklelem { get; set; }
    }
}
