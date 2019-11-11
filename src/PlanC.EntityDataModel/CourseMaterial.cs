using PlanC.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanC.EntityDataModel
{
    public class CourseMaterial
    {
        public string CrsId { get; set; }
        public string TchrUid { get; set; }
        public DateTime PlnVsnCdttm { get; set; }
        public string SmstrId { get; set; }
        public short CrsMtrlSqnbr { get; set; }
        public string CrsMtrlDesc { get; set; }
        public DateTime? RcdCdttm { get; set; }
        public string TrkUid { get; set; }

        public virtual CoursePlan Tcrspln { get; set; }
    }
}
