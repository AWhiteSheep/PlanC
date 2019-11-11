using System;
using System.Collections.Generic;

namespace PlanC.Web.Client.Models2
{
    public partial class Trole
    {
        public Trole()
        {
            Tuserrole = new HashSet<Tuserrole>();
        }

        public int RoleId { get; set; }
        public string RoleNm { get; set; }
        public DateTime? RcdCdttm { get; set; }

        public virtual ICollection<Tuserrole> Tuserrole { get; set; }
    }
}
