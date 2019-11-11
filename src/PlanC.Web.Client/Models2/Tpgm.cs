using System;
using System.Collections.Generic;

namespace PlanC.Web.Client.Models2
{
    public partial class Tpgm
    {
        public Tpgm()
        {
            Tcrstmplt = new HashSet<Tcrstmplt>();
            Tskl = new HashSet<Tskl>();
        }

        public string PgmId { get; set; }
        public int DptmntId { get; set; }
        public string PgmTitle { get; set; }
        public string PgmDesc { get; set; }
        public string PgmTyCd { get; set; }
        public DateTime? RcdCdttm { get; set; }
        public string TrkUid { get; set; }

        public virtual Tdptmnt Dptmnt { get; set; }
        public virtual ICollection<Tcrstmplt> Tcrstmplt { get; set; }
        public virtual ICollection<Tskl> Tskl { get; set; }
    }
}
