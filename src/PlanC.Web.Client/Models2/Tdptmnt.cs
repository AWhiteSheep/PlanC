using System;
using System.Collections.Generic;

namespace PlanC.Web.Client.Models2
{
    public partial class Tdptmnt
    {
        public Tdptmnt()
        {
            Tpgm = new HashSet<Tpgm>();
            Tuser = new HashSet<Tuser>();
        }

        public int DptmntId { get; set; }
        public string DptmntTitle { get; set; }
        public string DptmntPlcy { get; set; }
        public DateTime? RcdCdttm { get; set; }
        public string TrkUid { get; set; }

        public virtual ICollection<Tpgm> Tpgm { get; set; }
        public virtual ICollection<Tuser> Tuser { get; set; }
    }
}
