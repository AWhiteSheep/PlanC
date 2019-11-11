using System;
using System.Collections.Generic;

namespace PlanC.Web.Client.Models2
{
    public partial class Tcrsreq
    {
        public string CrsId { get; set; }
        public DateTime VsnCdttm { get; set; }
        public string ReqCrsId { get; set; }
        public DateTime? RcdCdttm { get; set; }
        public string CrsReqTyCd { get; set; }
        public string TrkUid { get; set; }

        public virtual Tcrstmplt Tcrstmplt { get; set; }
    }
}
