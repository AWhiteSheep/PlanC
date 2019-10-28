using System;
using System.Collections.Generic;

namespace PlanCadre.Data
{
    public partial class Tcrstmplt
    {
        public Tcrstmplt()
        {
            Tcrsreq = new HashSet<Tcrsreq>();
            Tcrssklelem = new HashSet<Tcrssklelem>();
            Tfnlexam = new HashSet<Tfnlexam>();
        }

        public string CrsId { get; set; }
        public DateTime VsnCdttm { get; set; }
        public string PgmId { get; set; }
        public string CrsTitle { get; set; }
        public decimal? Units { get; set; }
        public string CrsDesc { get; set; }
        public string CrsIntent { get; set; }
        public DateTime? DptmntApprvDt { get; set; }
        public DateTime? CmteApprvDt { get; set; }
        public DateTime? BoardApprvDt { get; set; }
        public string TrkUid { get; set; }
        public DateTime? RcdCdttm { get; set; }

        public virtual Tpgm Pgm { get; set; }
        public virtual ICollection<Tcrsreq> Tcrsreq { get; set; }
        public virtual ICollection<Tcrssklelem> Tcrssklelem { get; set; }
        public virtual ICollection<Tfnlexam> Tfnlexam { get; set; }
    }
}
