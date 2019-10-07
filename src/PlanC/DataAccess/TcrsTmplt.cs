using System;
using System.Collections.Generic;

namespace PlanC.DataAccess
{
    public partial class TcrsTmplt
    {
        public TcrsTmplt()
        {
            Tskltmplt = new HashSet<Tskltmplt>();
        }

        public string CrsId { get; set; }
        public int? DptmntId { get; set; }
        public string CrsTitle { get; set; }
        public decimal? Units { get; set; }
        public string CrsDesc { get; set; }
        public string Intent { get; set; }
        public DateTime? DptmtApprvlDt { get; set; }
        public DateTime? CmteApprvlDt { get; set; }
        public DateTime? BoardApprovlDt { get; set; }
        public string TrackingUid { get; set; }
        public DateTime? RecordCdttm { get; set; }

        public virtual ICollection<Tskltmplt> Tskltmplt { get; set; }
    }
}
