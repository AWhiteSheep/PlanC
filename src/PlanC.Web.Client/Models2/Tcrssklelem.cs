using System;
using System.Collections.Generic;

namespace PlanC.Web.Client.Models2
{
    public partial class Tcrssklelem
    {
        public string CrsId { get; set; }
        public DateTime VsnCdttm { get; set; }
        public string SklId { get; set; }
        public short SklelemSqnbr { get; set; }
        public string PrtlSklInd { get; set; }
        public string TxnmyCd { get; set; }
        public string AddtnlDesc { get; set; }
        public DateTime? RcdCdttm { get; set; }
        public string TrkUid { get; set; }

        public virtual Tsklelem Skl { get; set; }
        public virtual Tcrstmplt Tcrstmplt { get; set; }
    }
}
