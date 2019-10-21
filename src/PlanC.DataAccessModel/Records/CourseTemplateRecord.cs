using System;
using System.Collections.Generic;

namespace PlanC.DataAccessModel.Records
{
    public partial class CourseTemplateRecord
    {
        public string Id { get; set; }
        public int? DepartmentId { get; set; }
        public string Title { get; set; }
        public decimal? Units { get; set; }
        public string Description { get; set; }
        public string Intent { get; set; }
        public DateTime? DepartmentApprovalDate { get; set; }
        public DateTime? ComiteeApprovalDate { get; set; }
        public DateTime? BoardApprovalDate { get; set; }
        public string TrackingUserId { get; set; }
        public DateTime? TimeStamp { get; set; }
    }
}
