using System;
using System.Collections.Generic;

namespace PlanCadre.Data
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

        public virtual Tdptmnt Dptmnt { get; set; }
        public virtual ICollection<Tcrstmplt> Tcrstmplt { get; set; }
        public virtual ICollection<Tskl> Tskl { get; set; }
    }
}
