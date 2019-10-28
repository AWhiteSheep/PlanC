using System;
using System.Collections.Generic;

namespace PlanCadre.Data
{
    public partial class Tcd
    {
        public string CdTy { get; set; }
        public string Cd { get; set; }
        public string CdDesc { get; set; }
        public string TrkUid { get; set; }
        public DateTime? RcdCdttm { get; set; }

        public virtual Tcdty CdTyNavigation { get; set; }
    }
}
