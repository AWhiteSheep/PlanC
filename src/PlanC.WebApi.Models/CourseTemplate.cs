using System;
using System.Collections.Generic;

namespace PlanC.WebApi.Models
{
    public partial class CourseTemplate
    {
        public CourseTemplate()
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

        public Tpgm Pgm { get; set; }
        public ICollection<Tcrsreq> Tcrsreq { get; set; }
        public ICollection<Tcrssklelem> Tcrssklelem { get; set; }
        public ICollection<Tfnlexam> Tfnlexam { get; set; }
    }
}
