using PlanC.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanC.EntityDataModel
{
    public class SkillElementPerformanceCriteria
    {
        public string SklId { get; set; }
        public short SklElemSqnbr { get; set; }
        public short SklElemCrtSqnbr { get; set; }
        public string SklElemCrtTitle { get; set; }
        //public DateTime RcdCdttm { get; set; }
        public string TrkUid { get; set; }

        public virtual SkillElement SkillElement { get; set; }
    }
}
