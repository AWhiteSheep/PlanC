using System;
using System.Collections.Generic;

namespace PlanCadre.Data
{
    public partial class Tsklelem
    {
        public Tsklelem()
        {
            Tcrssklelem = new HashSet<Tcrssklelem>();
            Texamsklelem = new HashSet<Texamsklelem>();
        }

        public string SklId { get; set; }
        public short SklelemSqnbr { get; set; }
        public string SklelemTitle { get; set; }
        public string SklelemDesc { get; set; }
        public string TrkUid { get; set; }
        public DateTime? RcdCdttm { get; set; }

        public virtual Tskl Skl { get; set; }
        public virtual ICollection<Tcrssklelem> Tcrssklelem { get; set; }
        public virtual ICollection<Texamsklelem> Texamsklelem { get; set; }
    }
}
