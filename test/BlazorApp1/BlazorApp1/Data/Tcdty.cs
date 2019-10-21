using System;
using System.Collections.Generic;

namespace BlazorApp1.Data
{
    public partial class Tcdty
    {
        public Tcdty()
        {
            Tcd = new HashSet<Tcd>();
        }

        public string CdTy { get; set; }
        public string CdTyDesc { get; set; }
        public string TrkUid { get; set; }
        public DateTime? RcdCdttm { get; set; }

        public virtual ICollection<Tcd> Tcd { get; set; }
    }
}
