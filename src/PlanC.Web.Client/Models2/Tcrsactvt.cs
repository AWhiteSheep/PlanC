using System;
using System.Collections.Generic;

namespace PlanC.Web.Client.Models2
{
    public partial class Tcrsactvt
    {
        public Tcrsactvt()
        {
            Tactelem = new HashSet<Tactelem>();
        }

        public string CrsId { get; set; }
        public string TchrUid { get; set; }
        public DateTime PlnVsnCdttm { get; set; }
        public string SmstrId { get; set; }
        public short ActvtSqnbr { get; set; }
        public short? ActvtLgnth { get; set; }
        public string ActvtDesc { get; set; }
        public DateTime? RcdCdttm { get; set; }
        public string TrkUid { get; set; }

        public virtual Tcrspln Tcrspln { get; set; }
        public virtual ICollection<Tactelem> Tactelem { get; set; }
    }
}
