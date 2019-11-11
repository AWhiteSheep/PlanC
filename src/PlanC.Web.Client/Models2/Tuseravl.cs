using System;
using System.Collections.Generic;

namespace PlanC.Web.Client.Models2
{
    public partial class Tuseravl
    {
        public string Uid { get; set; }
        public int UserAvlSqnbr { get; set; }
        public int WeekdayNbr { get; set; }
        public TimeSpan AvlStm { get; set; }
        public TimeSpan AvlNtm { get; set; }
        public DateTime? RcdCdttm { get; set; }

        public virtual Tuser U { get; set; }
    }
}
