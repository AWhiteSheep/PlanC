using PlanC.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanC.EntityDataModel
{
    public class CourseActivityElement
    {
        public short SklelemSqnbr { get; set; }
        public string SklId { get; set; }
        public string CrsId { get; set; }
        public string TchrUid { get; set; }
        public DateTime PlnVsnCdttm { get; set; }
        public string SmstrId { get; set; }
        public short ActvtSqnbr { get; set; }
        public DateTime? RcdCdttm { get; set; }
        public string TrkUid { get; set; }

        public virtual SkillElement SkillElement { get; set; }
        public virtual CourseActivity Tcrsactvt { get; set; }
    }
}
