using System;

namespace PlanC.EntityDataModel
{
    public class UserAvailability
    {
        public string Uid { get; set; }
        public int UserAvlSqnbr { get; set; }
        public int WeekdayNbr { get; set; }
        public TimeSpan AvlStm { get; set; }
        public TimeSpan AvlNtm { get; set; }
        public DateTime? RcdCdttm { get; set; }

        public virtual User User { get; set; }
    }
}