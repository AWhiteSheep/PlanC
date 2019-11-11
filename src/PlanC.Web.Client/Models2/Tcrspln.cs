using System;
using System.Collections.Generic;

namespace PlanC.Web.Client.Models2
{
    public partial class Tcrspln
    {
        public Tcrspln()
        {
            Tcertexam = new HashSet<Tcertexam>();
            Tcrsactvt = new HashSet<Tcrsactvt>();
            Tcrsmtrl = new HashSet<Tcrsmtrl>();
        }

        public string CrsId { get; set; }
        public string TchrUid { get; set; }
        public DateTime PlnVsnCdttm { get; set; }
        public string SmstrId { get; set; }
        public DateTime? RcdCdttm { get; set; }
        public string TrkUid { get; set; }

        public virtual Tsmstr Smstr { get; set; }
        public virtual ICollection<Tcertexam> Tcertexam { get; set; }
        public virtual ICollection<Tcrsactvt> Tcrsactvt { get; set; }
        public virtual ICollection<Tcrsmtrl> Tcrsmtrl { get; set; }
    }
}
