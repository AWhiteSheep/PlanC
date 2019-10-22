using System;
using System.Collections.Generic;

namespace PlanC.WebApi.Models
{
    public partial class Department
    {
        public Department()
        {
            Tpgm = new HashSet<Tpgm>();
        }

        public int DptmntId { get; set; }
        public string DptmntDesc { get; set; }
        public string DptmntPlcy { get; set; }
        public DateTime? RcdCdttm { get; set; }
        public string TrkUid { get; set; }

        public ICollection<Tpgm> Tpgm { get; set; }
    }
}
