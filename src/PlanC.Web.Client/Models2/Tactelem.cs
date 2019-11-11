using System;
using System.Collections.Generic;

namespace PlanC.Web.Client.Models2
{
    public partial class Tactelem
    {
        public short SklelemSqnbr { get; set; }
        public string SklId { get; set; }
        public string CrsId { get; set; }
        public string TchrUid { get; set; }
        public DateTime PlnVsnCdttm { get; set; }
        public string SmstrId { get; set; }
        public short ActvtSqnbr { get; set; }
        public DateTime? RcdCdttm { get; set; }
        public string TrkUid { get; set; }

        public virtual Tsklelem Skl { get; set; }
        public virtual Tcrsactvt Tcrsactvt { get; set; }
    }
}
