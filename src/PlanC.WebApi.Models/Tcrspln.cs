using System;
using System.Collections.Generic;

namespace PlanC.WebApi.Models
{
    public partial class Tcrspln
    {
        public string CrsId { get; set; }
        public string TchrUid { get; set; }
        public DateTime PlnVsnCdttm { get; set; }
        public string SmstrId { get; set; }

        public Tsmstr Smstr { get; set; }
    }
}
