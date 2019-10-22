using System;
using System.Collections.Generic;

namespace BlazorApp1.Data
{
    public partial class Tcrspln
    {
        public string CrsId { get; set; }
        public string TchrUid { get; set; }
        public DateTime PlnVsnCdttm { get; set; }
        public string SmstrId { get; set; }

        public virtual Tsmstr Smstr { get; set; }
    }
}
