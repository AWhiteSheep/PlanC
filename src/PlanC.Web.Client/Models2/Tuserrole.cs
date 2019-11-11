using System;
using System.Collections.Generic;

namespace PlanC.Web.Client.Models2
{
    public partial class Tuserrole
    {
        public string Uid { get; set; }
        public int RoleId { get; set; }
        public DateTime? RcdCdttm { get; set; }

        public virtual Trole Role { get; set; }
        public virtual Tuser U { get; set; }
    }
}
