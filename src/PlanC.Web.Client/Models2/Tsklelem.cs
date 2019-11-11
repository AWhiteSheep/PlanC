using System;
using System.Collections.Generic;

namespace PlanC.Web.Client.Models2
{
    public partial class Tsklelem
    {
        public Tsklelem()
        {
            Tactelem = new HashSet<Tactelem>();
            Tcrssklelem = new HashSet<Tcrssklelem>();
            Texamsklelem = new HashSet<Texamsklelem>();
            Tsklelemcrt = new HashSet<Tsklelemcrt>();
        }

        public string SklId { get; set; }
        public short SklelemSqnbr { get; set; }
        public string SklelemTitle { get; set; }
        public string SklelemDesc { get; set; }
        public DateTime? RcdCdttm { get; set; }
        public string TrkUid { get; set; }

        public virtual Tskl Skl { get; set; }
        public virtual ICollection<Tactelem> Tactelem { get; set; }
        public virtual ICollection<Tcrssklelem> Tcrssklelem { get; set; }
        public virtual ICollection<Texamsklelem> Texamsklelem { get; set; }
        public virtual ICollection<Tsklelemcrt> Tsklelemcrt { get; set; }
    }
}
