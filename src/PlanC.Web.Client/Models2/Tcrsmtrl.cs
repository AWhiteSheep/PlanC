using System;
using System.Collections.Generic;

namespace PlanC.Web.Client.Models2
{
    public partial class Tcrsmtrl
    {
        public string CrsId { get; set; }
        public string TchrUid { get; set; }
        public DateTime PlnVsnCdttm { get; set; }
        public string SmstrId { get; set; }
        public short CrsMtrlSqnbr { get; set; }
        public string CrsMtrlDesc { get; set; }
        public DateTime? RcdCdttm { get; set; }
        public string TrkUid { get; set; }

        public virtual Tcrspln Tcrspln { get; set; }
    }
}
