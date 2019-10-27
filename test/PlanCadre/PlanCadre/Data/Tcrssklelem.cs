using System;
using System.Collections.Generic;

namespace PlanCadre.Data
{
    public partial class Tcrssklelem
    {
        public string CrsId { get; set; }
        public DateTime VsnCdttm { get; set; }
        public string SklId { get; set; }
        public short SklelemSqnbr { get; set; }
        public string PrtlSklInd { get; set; }
        public string TxnmyCd { get; set; }

        public virtual Tsklelem Skl { get; set; }
        public virtual Tcrstmplt Tcrstmplt { get; set; }
    }
}
