using System;
using System.Collections.Generic;

namespace BlazorApp1.Data
{
    public partial class Tdptmnt
    {
        public Tdptmnt()
        {
            Tpgm = new HashSet<Tpgm>();
        }

        public int DptmntId { get; set; }
        public string DptmntDesc { get; set; }
        public string DptmntPlcy { get; set; }
        public DateTime? RcdCdttm { get; set; }
        public string TrkUid { get; set; }

        public virtual ICollection<Tpgm> Tpgm { get; set; }
    }
}
