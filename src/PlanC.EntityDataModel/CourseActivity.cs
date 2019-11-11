using PlanC.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanC.EntityDataModel
{
    public class CourseActivity
    {
        public CourseActivity()
        {
            ActivityElements = new HashSet<CourseActivityElement>();
        }

        public string CrsId { get; set; }
        public string TchrUid { get; set; }
        public DateTime PlnVsnCdttm { get; set; }
        public string SmstrId { get; set; }
        public short ActvtSqnbr { get; set; }
        public short? ActvtLgnth { get; set; }
        public string ActvtDesc { get; set; }
        public DateTime? RcdCdttm { get; set; }
        public string TrkUid { get; set; }

        public virtual CoursePlan CoursePlan { get; set; }
        public virtual ICollection<CourseActivityElement> ActivityElements { get; set; }
    }
}
