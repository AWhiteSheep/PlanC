using System;
using System.Collections.Generic;

namespace PlanC.Web.Client.Models2
{
    public partial class Tuser
    {
        public Tuser()
        {
            Tuseravl = new HashSet<Tuseravl>();
            Tuserrole = new HashSet<Tuserrole>();
        }

        public string Uid { get; set; }
        public int? DptmntId { get; set; }
        public string GvnNm { get; set; }
        public string Snm { get; set; }
        public DateTime? RcdCdttm { get; set; }

        public virtual Tdptmnt Dptmnt { get; set; }
        public virtual ICollection<Tuseravl> Tuseravl { get; set; }
        public virtual ICollection<Tuserrole> Tuserrole { get; set; }
    }
}
