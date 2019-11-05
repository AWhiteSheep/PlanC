using System;
using System.Collections.Generic;

namespace PlanC.WebApi.Models
{
    public partial class Tpgm
    {
        public Tpgm()
        {
            Tcrstmplt = new HashSet<CourseTemplate>();
            Tskl = new HashSet<Skill>();
        }

        public string PgmId { get; set; }
        public int DptmntId { get; set; }
        public string PgmTitle { get; set; }
        public string PgmDesc { get; set; }
        public string PgmTyCd { get; set; }

        public Department Dptmnt { get; set; }
        public ICollection<CourseTemplate> Tcrstmplt { get; set; }
        public ICollection<Skill> Tskl { get; set; }
    }
}
